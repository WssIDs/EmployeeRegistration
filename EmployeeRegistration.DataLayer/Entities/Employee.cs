using System;
using System.Data.SqlClient;

namespace EmployeeRegistration.DataLayer.Entities
{
    /// <summary>
    /// Класс сущности - Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата приёма на работу 
        /// </summary>
        public DateTime EmploymentDate { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public Employee() { }

        public Employee(SqlDataReader reader)
        {
            EmployeeId = (int)reader["EmployeeId"];
            Surname = (string)reader["Surname"];
            FirstName = (string)reader["FirstName"];
            MiddleName = (string)reader["MiddleName"];
            EmploymentDate = (DateTime)reader["EmploymentDate"];
            Position = (string)reader["Position"];
            CompanyId = (int)reader["CompanyId"];

            Company = new Company(reader);

        }
    }
}
