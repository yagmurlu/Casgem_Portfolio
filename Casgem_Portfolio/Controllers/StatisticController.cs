using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            ViewBag.emplyoyeeCount = db.TblEmployee.Count();
            //var salary = db.TblEmployee.Max(x => x.EmployeeName);
            //ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select
            //    (y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount=db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);
            ViewBag.countSoftwareDepartment=db.TblEmployee.Where(x=>x.EmployeeDepartment==db.TblDepartment.Where
            (z=>z.DepartmentName=="Yazılım").Select(y=>y.DepartmentID).FirstOrDefault()).Count();

            ViewBag.cityAnkaraOrAdanaSumSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Adana" || x.EmployeeCity == "Ankara").Sum(y => y.EmployeeSalary);

            ViewBag.cityAnkaraSoftwareSumSallary =
                db.TblEmployee.Where(x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartment.Where(z => z.DepartmentName == "yazılım")
                .Select(y => y.DepartmentID).FirstOrDefault()).Sum(a => a.EmployeeSalary);
            return View();

      
            
        }
    }
}