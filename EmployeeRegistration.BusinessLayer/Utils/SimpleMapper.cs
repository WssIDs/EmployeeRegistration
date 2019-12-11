using EmployeeRegistration.BusinessLayer.Models;
using EmployeeRegistration.DataLayer.Entities;

namespace EmployeeRegistration.BusinessLayer.Utils
{
    /// <summary>
    /// Класс для проецирования одной модели на другую
    /// </summary>
    public class SimpleMapper
    {
        /// <summary>
        /// Проецирование CompanyViewModel в Company
        /// </summary>
        public static Company MapFromViewModel(CompanyViewModel company)
        {
            Company c = new Company();
            c.CompanyId = company.CompanyId;
            c.CompanyName = company.CompanyName;
            c.CompanySize = company.CompanySize;
            c.LegalForm = company.LegalForm;
            c.ActivityType = company.ActivityType;

            return c;
        }

        /// <summary>
        /// Проецирование EmployeeViewModel в Employee
        /// </summary>
        public static Employee MapFromViewModel(EmployeeViewModel employee)
        {
            Employee e = new Employee();
            e.EmployeeId = employee.EmployeeId;
            e.Surname = employee.Surname;
            e.FirstName = employee.FirstName;
            e.MiddleName = employee.MiddleName;
            e.EmploymentDate = employee.EmploymentDate;
            e.Position = employee.Position;
            e.CompanyId = employee.CompanyId;

            if (employee.Company != null)
            {
                e.Company = MapFromViewModel(employee.Company);
            }

            return e;
        }

        /// <summary>
        /// Проецирование Company в CompanyViewModel
        /// </summary>
        public static CompanyViewModel MapToViewModel(Company company)
        {
            CompanyViewModel c = new CompanyViewModel();
            c.CompanyId = company.CompanyId;
            c.CompanyName = company.CompanyName;
            c.CompanySize = company.CompanySize;
            c.LegalForm = company.LegalForm;
            c.ActivityType = company.ActivityType;

            return c;
        }

        /// <summary>
        /// Проецирование Employee в EmployeeViewModel
        /// </summary>
        public static EmployeeViewModel MapToViewModel(Employee employee)
        {
            EmployeeViewModel e = new EmployeeViewModel();
            e.EmployeeId = employee.EmployeeId;
            e.Surname = employee.Surname;
            e.FirstName = employee.FirstName;
            e.MiddleName = employee.MiddleName;
            e.Position = employee.Position;
            e.EmploymentDate = employee.EmploymentDate;
            e.CompanyId = employee.CompanyId;
            
            if (employee.Company != null)
            {
                e.Company = MapToViewModel(employee.Company);
            }

            return e;
        }
    }
}
