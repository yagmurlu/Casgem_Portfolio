using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values=db.TblSocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocial(TblSocialMedia p)
        {
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocial(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocial(TblSocialMedia p)
        {
            var value = db.TblSocialMedia.Find(p.SocialMediaId);
            value.SocialMediaName = p.SocialMediaName;
            value.SocialMediaURL = p.SocialMediaURL;
            value.SocialMediaIcon = p.SocialMediaIcon;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}