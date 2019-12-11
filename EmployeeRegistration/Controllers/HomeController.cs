using EmployeeRegistration.BusinessLayer.Interfaces;
using EmployeeRegistration.BusinessLayer.Services;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EmployeeRegistration.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeService employeeService;
        ICompanyService companyService;

        public HomeController()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeRegistration"].ConnectionString;
            companyService = new CompanyService(connectionString);
            employeeService = new EmployeeService(connectionString);
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Employees()
        {
            return PartialView("Partial/EmployeesPartial", employeeService.GetAll());
        }

        public PartialViewResult Companies()
        {
            return PartialView("Partial/CompaniesPartial", companyService.GetAll());
        }
    }
}