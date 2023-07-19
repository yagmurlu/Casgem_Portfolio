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
			var values = db.TblSocialMedia.ToList();
			return PartialView(values);
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
			ViewBag.title = db.TblAbout.Select(x => x.AboutTitle).FirstOrDefault();
			ViewBag.description = db.TblAbout.Select(x => x.AboutDescription).FirstOrDefault();
			return PartialView();
        }
		public ActionResult Download()
		{
			ViewBag.cv = db.TblAbout.Select(x => x.CvURL).FirstOrDefault();
			string filePath = Server.MapPath("~/Templates/" + ViewBag.cv);
			return File(filePath, "application/pdf", ViewBag.cv);
		}
		public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values=db.TblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialVideo()
        {
            //ViewBag.title = db.TblVideo.Select(x => x.Title).FirstOrDefault();
            //ViewBag.description = db.TblVideo.Select(x => x.Description).FirstOrDefault();
            //ViewBag.video = db.TblVideo.Select(x => x.Frame).FirstOrDefault();
            ViewBag.title = db.TblVideo.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = db.TblVideo.Select(x => x.Description).FirstOrDefault();
            ViewBag.video = db.TblVideo.Select(x => x.VideoURL).FirstOrDefault();
            //ViewBag.video2 = db.TblVideo.Select(x => x.VideoURL2).FirstOrDefault();
            return PartialView();
            //var values=db.TblVideo.ToList();
            //return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            var textArray = db.TblSkill.Select(x => x.SkillName).ToArray();

            ViewBag.skillArray = textArray;

            return PartialView();
        }

      
    }
}