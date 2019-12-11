using System.Data.SqlClient;

namespace EmployeeRegistration.DataLayer.Entities
{
    /// <summary>
    /// Класс сущности - Компания
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Размер компании
        /// </summary>
        public int CompanySize { get; set; }
        /// <summary>
        /// Организационно-правовая форма 
        /// </summary>
        public string LegalForm { get; set; }
        /// <summary>
        /// Вид деятельности
        /// </summary>
        public string ActivityType { get; set; }

        public Company() { }

        public Company(SqlDataReader reader)
        {
            CompanyId = (int)reader["CompanyId"];
            CompanyName = (string)reader["CompanyName"];
            CompanySize = (int)reader["CompanySize"];
            LegalForm = reader["LegalForm"].ToString();
            ActivityType = reader["ActivityType"].ToString();
        }
    }
}
