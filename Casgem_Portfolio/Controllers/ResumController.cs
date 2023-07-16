using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ResumController : Controller
    {
        // GET: Result
        CasgemPortfolioEntities1  db =new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblResume.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddResum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddResum(TblResume p)
        {
            db.TblResume.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteResum(int id)
        {
            var value = db.TblResume.Find(id);
            db.TblResume.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditResum(int id)
        {
            var value = db.TblResume.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditResum(TblResume p)
        {
            var value = db.TblResume.Find(p.Id);
            value.Title1 = p.Title1;
            value.Title2 = p.Title2;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}