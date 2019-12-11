using EmployeeRegistration.DataLayer.Entities;
using EmployeeRegistration.DataLayer.Interfaces;

namespace EmployeeRegistration.DataLayer.Repository
{
    /// <summary>
    /// Класс взаимодействия с бд
    /// </summary>
    public class EntityUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Строка подключения к бд
        /// </summary>
        readonly string connectionstring;

        CompanyRepository companyRepository;
        EmployeeRepository employeeRepository;

        public EntityUnitOfWork(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        /// <summary>
        /// Репозиторий сущностей компаний
        /// </summary>
        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                {
                    companyRepository = new CompanyRepository(connectionstring);
                }

                return companyRepository;
            }
        }

        /// <summary>
        /// Репозиторий сущностей работников
        /// </summary>
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(connectionstring);
                }

                return employeeRepository;
            }
        }
    }
}
