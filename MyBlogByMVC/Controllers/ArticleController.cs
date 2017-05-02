using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MyBlogByMVC.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public ActionResult ArticleAdd()
        {
            return View();
        }
        [HttpPost]
        public string GetArticle(int pageIndex,int type)
        {
            //分页
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int startRow = (pageIndex - 1) * pageSize;
            //初始化
            List<Article> articles = new List<Article>();
            int total = 0;
            using (var context = new MyBlogEntities())
            {
                articles = (from a in context.Article 
                           where a.type == type select a).ToList();
                //articles = context.Article.Select(a => a).ToList();
                if (articles.Count!=0)
                {
                    articles = articles.Skip(startRow).Take(pageSize).ToList();
                }
                total = articles.Count;
                foreach (var model in articles)
                {
                    model.Content = Common.Common.RemoveTag(model.Content);
                }
            }
            return "{\"total\":" + total + ",\"rows\":" + new JavaScriptSerializer().Serialize(articles) + "}";      
        }
        /// <summary>
        /// 增加文章
        /// </summary>
        /// <param name="Form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticle(FormCollection Form)
        {
            //分页
            using (var context = new MyBlogEntities())
            {

                var ArticleList = context.Article.ToList<Article>();
                //增加
                context.Article.Add(new Article() { Title = Form[1], Content = Form[2], AddTime = DateTime.Now, ViewCount = 0, type = Convert.ToInt32(Form[0]) });
                //更新
                Article articleToUpdate = new Article();
               // articleToUpdate.No = "Edited student1";
                //Perform delete operation
                //context.Students.Remove(studentList.ElementAt<Student>(0));
                //Execute Inser, Update & Delete queries in the database
                return Json(context.SaveChanges() > 0 ? 1 : -1);
            }
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="Form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateArticle(FormCollection Form)
        {
            //分页
            using (var context = new MyBlogEntities())
            {
                //获取需要更改的条目
                var articles = context.Article.ToList<Article>();
                var article = articles.Where(s => s.No == Convert.ToInt32(Form["no"])).FirstOrDefault<Article>();
                //更改数据
                article.Title = Form[0];
                article.Content = Form[1];
                //保存
                return Json(context.SaveChanges() > 0 ? 1 : -1);
            }
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="Form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetArticleInfo(int id)
        {
            //分页
            using (var context = new MyBlogEntities())
            {
                var articls = context.Article.ToList();
                var article = articls.SingleOrDefault(a => a.No == id);
                article.ViewCount++;
                context.SaveChanges();
                return Json(article);
            }
        }
    }
}