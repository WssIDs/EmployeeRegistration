using System.Collections.ObjectModel;

using EmployeeRegistration.BusinessLayer.Models;

namespace EmployeeRegistration.BusinessLayer.Interfaces
{
    /// <summary>
    /// Интерфейс взаимодействия Company и CompanyViewModel
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Получение коллеции моделей CompanyViewModel
        /// </summary>
        ObservableCollection<CompanyViewModel> GetAll();
        /// <summary>
        /// Получение модели преставления CompanyViewModel по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        CompanyViewModel Get(int id);
        /// <summary>
        /// Добавить модель в коллекцию
        /// </summary>
        /// <param name="company"></param>
        void AddCompany(CompanyViewModel company);
        void UpdateCompany(CompanyViewModel company);
        void DeleteCompany(int companyId);
    }
}
