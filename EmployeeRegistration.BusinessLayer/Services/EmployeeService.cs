using System.Collections.ObjectModel;

using EmployeeRegistration.BusinessLayer.Interfaces;
using EmployeeRegistration.BusinessLayer.Models;
using EmployeeRegistration.BusinessLayer.Utils;
using EmployeeRegistration.DataLayer.Entities;
using EmployeeRegistration.DataLayer.Interfaces;
using EmployeeRegistration.DataLayer.Repository;


namespace EmployeeRegistration.BusinessLayer.Services
{
    /// <summary>
    /// Релизация сервиса сотрудника
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Объект взаимодейсвтия с уровнем DAL
        /// </summary>
        IUnitOfWork database;

        public EmployeeService(string connectionstring)
        {
            database = new EntityUnitOfWork(connectionstring);
        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            Employee e = SimpleMapper.MapFromViewModel(employee);
            database.Employees.Create(e);
        }

        public void DeleteEmployee(int employeeId)
        {
            database.Employees.Delete(employeeId);
        }

        public EmployeeViewModel Get(int id)
        {
            Employee e = database.Employees.Get(id);
            return SimpleMapper.MapToViewModel(e);
        }

        public ObservableCollection<EmployeeViewModel> GetAll()
        {
            ObservableCollection<EmployeeViewModel> employeeViewModels = new ObservableCollection<EmployeeViewModel>();
            var employees = database.Employees.GetAll();

            foreach (var e in employees)
            {
                var c = database.Companies.Get(e.CompanyId);
                EmployeeViewModel employeeViewModel = SimpleMapper.MapToViewModel(e);
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public void UpdateEmployee(EmployeeViewModel employee)
        {
            Employee e = SimpleMapper.MapFromViewModel(employee);
            database.Employees.Update(e);
        }
    }
}
