using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlogByMVC;

namespace MyBlogByMVC.Controllers
{
    public class PhotoController : Controller
    {
        private MyBlogEntities db = new MyBlogEntities();

        // GET: /Photo/
        public ActionResult Index()
        {
            return View(db.Img.ToList());
        }

        [HttpPost]
        public string List(int type)
        {
            var Imgs = db.Img.ToList();
            var total = Imgs.Count;
            return "{\"total\":" + total + ",\"rows\":" + Common.Common.ModelToJson(Imgs) + "}";
        }

        // GET: /Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img img = db.Img.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        // GET: /Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Photo/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="No,Path,Description,AddTime,R1,R2,R3,Width,Height")] Img img)
        {
            if (ModelState.IsValid)
            {
                db.Img.Add(img);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(img);
        }

        // GET: /Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img img = db.Img.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        // POST: /Photo/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,Path,Description,AddTime,R1,R2,R3,Width,Height")] Img img)
        {
            if (ModelState.IsValid)
            {
                db.Entry(img).State =System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(img);
        }

        // GET: /Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img img = db.Img.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        // POST: /Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Img img = db.Img.Find(id);
            db.Img.Remove(img);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
