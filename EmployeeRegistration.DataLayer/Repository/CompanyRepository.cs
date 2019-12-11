using System.Collections.Generic;
using System.Data.SqlClient;

using EmployeeRegistration.DataLayer.Utils;
using EmployeeRegistration.DataLayer.Entities;
using EmployeeRegistration.DataLayer.Interfaces;

namespace EmployeeRegistration.DataLayer.Repository
{
    /// <summary>
    /// Класс реализации репозитория компаний
    /// </summary>
    public class CompanyRepository : IRepository<Company>
    {
        string connectionstring;

        public CompanyRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void Create(Company t)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Company_Insert";

            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("CompanyName",t.CompanyName),
                new SqlParameter("LegalForm", t.LegalForm),
                new SqlParameter("ActivityType", t.ActivityType)
            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }

        public void Delete(int id)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Company_DeleteById";
            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("CompanyId",id),
            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }


        public Company Get(int id)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Company_GetById";
            Company company = null;
            SqlDataReader reader = Database.GetStorageProc(Query, new List<SqlParameter>() { new SqlParameter("CompanyId", id) });

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    company = new Company(reader);
                }
            }

            Database.CloseConnection();

            return company;
        }

        public IEnumerable<Company> GetAll()
        {
            Database.OpenConnection(connectionstring);

            string Query = "Company_GetAll";
            List<Company> companies = new List<Company>();

            SqlDataReader reader = Database.GetStorageProc(Query, null);
            if(reader != null && reader.HasRows)
            {
                while(reader.Read())
                {
                    Company company = new Company(reader);
                    companies.Add(company);
                }
            }

            Database.CloseConnection();

            return companies;
        }

        public void Update(Company t)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Company_Update";

            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("CompanyName",t.CompanyName),
                new SqlParameter("LegalForm", t.LegalForm),
                new SqlParameter("ActivityType", t.ActivityType),
                new SqlParameter("CompanyId", t.CompanyId)

            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }
    }
}
