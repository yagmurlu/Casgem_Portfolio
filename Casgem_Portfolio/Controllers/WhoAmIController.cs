using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class WhoAmIController : Controller
    {
        // GET: About
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var value = db.TblAbout.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var value=db.TblAbout.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditAbout(TblAbout p)
        {
            var value = db.TblAbout.Find(p.AboutId);
            value.AboutTitle = p.AboutTitle;
            value.AboutDescription = p.AboutDescription;
            value.CvURL = p.CvURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}