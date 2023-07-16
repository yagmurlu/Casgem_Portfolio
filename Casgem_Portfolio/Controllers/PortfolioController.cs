using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead() 
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle = db.TblFeature.Select(x => x.FetaureTitle).FirstOrDefault();
            ViewBag.featureDescription=db.TblFeature.Select(x=>x.FeatureDescrition).FirstOrDefault();
            ViewBag.featureImage=db.TblFeature.Select(x=>x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult MyResum()
        {
            var values=db.TblResume.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x=>x.MessageSubject=="Teşkkür").Count();
            ViewBag.happyCustomer = 12;
            return PartialView();
        }
        public PartialViewResult PartialAbout() 
        {
            var values=db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }
        public PartialViewResult PartialVideo()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            var textArray = db.TblSkill.Select(x => x.SkillName).ToArray();

            ViewBag.skillArray = textArray;

            return PartialView();
        }
    }
}