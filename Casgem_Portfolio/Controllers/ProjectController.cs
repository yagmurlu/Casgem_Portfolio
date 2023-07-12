using Casgem_Portfolio.Models.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var value=db.Project.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddProject() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project p)
        {
            db.Project.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteProject(int id)
        {
            var value = db.Project.Find(id);
            db.Project.Remove(value); db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var value=db.Project.Find(id);
           
            return View(value);
        }
        [HttpPost]
        public ActionResult EditProject(Project p)
        {
            var value = db.Project.Find(p.ProjectID);
            value.ProjectName= p.ProjectName;
            value.ProfectDate = p.ProfectDate;
            value.ProjectDetails = p.ProjectDetails;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProjectDetails(int id)
        {
            var value = db.Project.Find(id);
            return View(value);
        }

    }
}