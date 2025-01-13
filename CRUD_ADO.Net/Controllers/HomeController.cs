using CRUD_ADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ADO.Net.Controllers
{
    public class HomeController : Controller
    {

        EmployeeDbContext _employeeDbContext = new EmployeeDbContext();

        public ActionResult Index()
        {
            return View(_employeeDbContext.getEmployeeList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (_employeeDbContext.InsertEmployee(employee))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeDbContext.getEmployeeList().Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (_employeeDbContext.UpdateEmployee(employee))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeDbContext.getEmployeeList().Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            if (_employeeDbContext.DeleteEmployee(id))
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}