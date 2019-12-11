using System;
using System.Web.Configuration;
using System.Web.Mvc;

using EmployeeRegistration.BusinessLayer.Interfaces;
using EmployeeRegistration.BusinessLayer.Models;
using EmployeeRegistration.BusinessLayer.Services;

namespace EmployeeRegistration.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService companyService;

        public CompanyController()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeRegistration"].ConnectionString;
            companyService = new CompanyService(connectionString);
        }

        // GET: Company
        public ActionResult Index()
        {
            return View(companyService.GetAll());
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            var company = new CompanyViewModel();

            return View("EntityForms/Create",company);
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    companyService.AddCompany(company);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyViewModel company = companyService.Get(id);

            return View("EntityForms/Edit",company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    companyService.UpdateCompany(company);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                   
                    return View(ex.Message);
                }
            }
            else return View(company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            CompanyViewModel company = companyService.Get(id);

            return View("EntityForms/Delete",company);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    companyService.DeleteCompany(id);

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else return View();
        }
    }
}
