using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            var value = db.TblVideo.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EditVideo(int id)
        {
            var value = db.TblVideo.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditVideo(TblVideo p)
        {
            var value = db.TblVideo.Find(p.VideoId);
            value.Title = p.Title;
            value.Description = p.Description;
            value.VideoURL = p.VideoURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}