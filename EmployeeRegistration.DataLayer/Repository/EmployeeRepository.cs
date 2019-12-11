using System.Collections.Generic;
using System.Data.SqlClient;

using EmployeeRegistration.DataLayer.Utils;
using EmployeeRegistration.DataLayer.Entities;
using EmployeeRegistration.DataLayer.Interfaces;

namespace EmployeeRegistration.DataLayer.Repository
{
    /// <summary>
    /// Класс реализации репозитория работников
    /// </summary>
    class EmployeeRepository : IRepository<Employee>
    {
        string connectionstring;

        public EmployeeRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void Create(Employee t)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Employee_Insert";
            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("Surname",t.Surname),
                new SqlParameter("FirstName", t.FirstName),
                new SqlParameter("MiddleName", t.MiddleName),
                new SqlParameter("EmploymentDate", t.EmploymentDate),
                new SqlParameter("Position", t.Position),
                new SqlParameter("CompanyId", t.CompanyId)
            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }

        public void Delete(int id)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Employee_DeleteById";
            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("EmployeeId",id),
            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }

        public Employee Get(int id)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Employee_GetById";
            Employee employee = null;

            SqlDataReader reader = Database.GetStorageProc(Query, new List<SqlParameter>() { new SqlParameter("EmployeeId", id) });
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    employee = new Employee(reader);
                }
            }

            Database.CloseConnection();

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            Database.OpenConnection(connectionstring);

            string Query = "Employee_GetAll";
            List<Employee> employees = new List<Employee>();

            SqlDataReader reader = Database.GetStorageProc(Query, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee employee = new Employee(reader);
                    employees.Add(employee);
                }
            }

            Database.CloseConnection();

            return employees;
        }

        public void Update(Employee t)
        {
            Database.OpenConnection(connectionstring);

            string Query = "Employee_Update";

            List<SqlParameter> Params = new List<SqlParameter>()
            {
                new SqlParameter("Surname",t.Surname),
                new SqlParameter("FirstName", t.FirstName),
                new SqlParameter("MiddleName", t.MiddleName),
                new SqlParameter("EmploymentDate", t.EmploymentDate),
                new SqlParameter("Position", t.Position),
                new SqlParameter("CompanyId", t.CompanyId),
                new SqlParameter("EmployeeId", t.EmployeeId)
            };

            Database.ExecStorageProc(Query, Params);

            Database.CloseConnection();
        }
    }
}
