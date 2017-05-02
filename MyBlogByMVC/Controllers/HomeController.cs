using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogByMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetPhoto()
        {
            List<Img> imgs = new List<Img>();//初始化list对象集合
            //使用EF连接数据库  (不知道这么说对不对..反正我瞎编的..大概作用是这个= =)
            using (var context = new MyBlogEntities())
            {
                //执行查询操作
                imgs = context.Img.Select(a => a).ToList();
            }
            //将数据转换成JSON类型传回给也没
            return Json(imgs);
        }
    }
}