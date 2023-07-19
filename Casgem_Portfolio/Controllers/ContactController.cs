using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Portfolio");
        }
        [HttpGet]
        public ActionResult GetContact()
        {
            var value=db.TblContact.ToList();
            return View(value);  
        }
		[HttpGet]
		public ActionResult UpdateContact(int id)
		{
			var value = db.TblContact.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateContact(TblContact contact)
		{
			var value = db.TblContact.Find(contact.ContactId);
			value.NumberPhone = contact.NumberPhone;
			value.Email = contact.Email;
			value.Location = contact.Location;
			db.SaveChanges();
			return RedirectToAction("GetContact");
		}
		public PartialViewResult MyContactInfo()
        {
			ViewBag.num = db.TblContact.Select(x => x.NumberPhone).FirstOrDefault();
			ViewBag.mail = db.TblContact.Select(x => x.Email).FirstOrDefault();
			ViewBag.location = db.TblContact.Select(x => x.Location).FirstOrDefault();
			return PartialView();
        }
    }
}