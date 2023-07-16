using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            var value = db.TblFeature.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditFeature(TblFeature p)
        {
            var value = db.TblFeature.Find(p.FeatureID);
            value.FetaureTitle = p.FetaureTitle;
            value.FeatureDescrition = p.FeatureDescrition;
            value.FeatureImageURL = p.FeatureImageURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}