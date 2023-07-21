using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            return View();
        }
        // About Section CRUD
        [HttpGet]
        public ActionResult GetAboutSection()
        {
            var values = db.TblAboutSection.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAboutSection(int id)
        {
            var value = db.TblAboutSection.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAboutSection(TblAboutSection p)
        {
            var value = db.TblAboutSection.Find(p.Id);
            value.Name_Surname = p.Name_Surname;
            value.Section = p.Section;
            value.Description = p.Description;
            value.City = p.City;
            value.Age = p.Age;
            value.Email = p.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Skill Bar Crud
        [HttpGet]
        public ActionResult GetAboutSkill()
        {
            var values = db.TblSkillsAbout.ToList();
            return View(values);
        }

        public ActionResult DeleteAboutSkill(int id)
        {
            var value = db.TblSkillsAbout.Find(id);
            db.TblSkillsAbout.Remove(value);
            db.SaveChanges();
            return RedirectToAction("GetAboutSkill");
        }
        [HttpGet]
        public ActionResult UpdateAboutScill(int id)
        {
            var value = db.TblSkillsAbout.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAboutScill(TblSkillsAbout p)
        {
            var value = db.TblSkillsAbout.Find(p.SkillIAboutd);
            value.SkillAboutName = p.SkillAboutName;
            value.Ratio = p.Ratio;
            db.SaveChanges();
            return RedirectToAction("GetAboutSkill");
        }
        
        [HttpGet]
        public ActionResult AddAboutSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAboutSkill(TblSkillsAbout p)
        {
            db.TblSkillsAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("GetAboutSkill");
        }


        //Partials
        public PartialViewResult PartialAbout()
		{
			return PartialView();
		}
        public PartialViewResult PartialAboutPageSection()
        {
            ViewBag.aboutName = db.TblAboutSection.Select(x => x.Name_Surname).FirstOrDefault();
            ViewBag.age = db.TblAboutSection.Select(x => x.Age).FirstOrDefault();
            ViewBag.section = db.TblAboutSection.Select(x => x.Section).FirstOrDefault();
            ViewBag.city = db.TblAboutSection.Select(x => x.City).FirstOrDefault();
            ViewBag.mail = db.TblAboutSection.Select(x => x.Email).FirstOrDefault();
            ViewBag.description = db.TblAboutSection.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialSkillsAbout()
        {
            var values = db.TblSkillsAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialMyProject()
        {
            var value = db.Project.ToList();
            return PartialView(value);
        }
    }
}