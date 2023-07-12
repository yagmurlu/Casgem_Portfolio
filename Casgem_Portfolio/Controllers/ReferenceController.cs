using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.Reference.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddReferance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReferance(Reference p)
        {
            db.Reference.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteReferance(int id)
        {
            var value = db.Reference.Find(id);
            db.Reference.Remove(value); db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditReferance(int id)
        {
            var value = db.Reference.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditReferance(Reference p)
        {
            var value = db.Reference.Find(p.ReferenceID);
            value.NameSurname = p.NameSurname;
            value.Mail = p.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}