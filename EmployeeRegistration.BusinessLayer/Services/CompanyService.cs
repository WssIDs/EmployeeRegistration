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
    /// Релизация сервиса компании
    /// </summary>
    public class CompanyService : ICompanyService
    {
        /// <summary>
        /// Объект взаимодейсвтия с уровнем DAL
        /// </summary>
        IUnitOfWork database;

        public CompanyService(string connectionstring)
        {
            database = new EntityUnitOfWork(connectionstring);
        }

        public void AddCompany(CompanyViewModel company)
        {
            Company c = SimpleMapper.MapFromViewModel(company);
            database.Companies.Create(c);
        }

        public void DeleteCompany(int companyId)
        {
            database.Companies.Delete(companyId);
        }

        public CompanyViewModel Get(int id)
        {
            Company c = database.Companies.Get(id);
            return SimpleMapper.MapToViewModel(c);
        }

        public ObservableCollection<CompanyViewModel> GetAll()
        {
            ObservableCollection<CompanyViewModel>  companyViewModels = new ObservableCollection<CompanyViewModel>();
            var companies = database.Companies.GetAll();

            foreach (var c in companies)
            {
                companyViewModels.Add(SimpleMapper.MapToViewModel(c));
            }

            return companyViewModels;
        }

        public void UpdateCompany(CompanyViewModel company)
        {
            Company c = SimpleMapper.MapFromViewModel(company);
            database.Companies.Update(c);
        }
    }
}
