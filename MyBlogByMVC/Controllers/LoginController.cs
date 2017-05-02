using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogByMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //登陆验证
        public ActionResult CheckLogin(string account, string pwd)
        {
            if (account == "zhf")
            {
                if (Common.Common.StrToMD5Str(pwd) == "80FDB382F40BE453F421006D5F40ADBB")
                {
                    Session["Id"] = "zhf";
                    return RedirectToAction("index", "admin", new { type=1 });
                }
            }
            return Content("<script>alert('账号或者密码错误');location.href='index'</script>");
        }

	}
}