using System.Collections.ObjectModel;

using EmployeeRegistration.BusinessLayer.Models;

namespace EmployeeRegistration.BusinessLayer.Interfaces
{
    public interface IEmployeeService
    {
        ObservableCollection<EmployeeViewModel> GetAll();
        EmployeeViewModel Get(int id);
        void AddEmployee(EmployeeViewModel employee);
        void UpdateEmployee(EmployeeViewModel employee);
        void DeleteEmployee(int employeeId);
    }
}
