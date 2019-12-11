using EmployeeRegistration.DataLayer.Entities;

namespace EmployeeRegistration.DataLayer.Interfaces
{
    /// <summary>
    /// Интерфейс для хранения в себе в всех репозиториев
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Репозиторий компаний
        /// </summary>
        IRepository<Company> Companies { get; }
        /// <summary>
        /// Репозиторий сотрудников
        /// </summary>
        IRepository<Employee> Employees { get; }
    }
}
