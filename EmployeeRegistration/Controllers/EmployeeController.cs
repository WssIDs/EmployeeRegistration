using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;

using EmployeeRegistration.BusinessLayer.Interfaces;
using EmployeeRegistration.BusinessLayer.Models;
using EmployeeRegistration.BusinessLayer.Services;

namespace EmployeeRegistration.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        ICompanyService companyService;

        public EmployeeController()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeRegistration"].ConnectionString;
            employeeService = new EmployeeService(connectionString);
            companyService = new CompanyService(connectionString);
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(employeeService.GetAll());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            TempData["Companies"] = companyService.GetAll();
            TempData["Positions"] = GetEmployeePostions();

            return View("EntityForms/Create",employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    employeeService.AddEmployee(employee);

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                EmployeeViewModel employee = employeeService.Get(id);
                TempData["Companies"] = companyService.GetAll();
                TempData["Positions"] = GetEmployeePostions();

                return View("EntityForms/Edit", employee);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    employeeService.UpdateEmployee(employee);

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeViewModel employee = employeeService.Get(id);
            return View("EntityForms/Delete", employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    employeeService.DeleteEmployee(id);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else return View();
        }

        public List<string> GetEmployeePostions()
        {
            return new List<string> {
                 "Разработчик",
                "Тестировщик",
                "Бизнес-аналитик",
                "Менеджер"
                };
        }
    }
}
