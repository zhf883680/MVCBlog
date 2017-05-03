using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogByMVC.Common
{
    public class BaseController : Controller
    {
        //要过滤的控制器可以继承此BaseController 

        /// <summary>
        /// 在控制器执行方法之前执行   
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)//protected 只能被子类访问
        {
            base.OnActionExecuted(filterContext);
            if (Session["Id"] == null)
            {
                filterContext.Result = Redirect("/Login/Index");//  没有返回值， 所以不是return   是filterContexr.Result  
            }
        }

    }
}