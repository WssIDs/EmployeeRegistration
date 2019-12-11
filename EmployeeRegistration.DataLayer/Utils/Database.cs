using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeRegistration.DataLayer.Utils
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class Database
    {
        /// <summary>
        /// класс подключения к базе
        /// </summary>
        private static SqlConnection Connection;
        /// <summary>
        /// класс команд
        /// </summary>
        private static SqlCommand Command;

        /// <summary>
        /// Открытие соединия с базой данных
        /// </summary>
        /// <param name="connectionstring">строка подключения к бд</param>
        /// <returns></returns>
        public static void OpenConnection(string connectionstring)
        {
            Connection = new SqlConnection(connectionstring);
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        /// <summary>
        /// Закрытие соединения с бд
        /// </summary>
        public static void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Получение записей из бд используя параметры 
        /// </summary>
        /// <param name="query">строка запроса</param>
        /// <param name="parameters">коллекция параметров</param>
        /// <returns>Объект с данными</returns>
        public static SqlDataReader Get(String query, List<SqlParameter> parameters)
        {
            Command = new SqlCommand(query, Connection);

            if(parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    Command.Parameters.Add(p);
                }
            }

            return Command.ExecuteReader();
        }

        /// <summary>
        /// Получение записей из бд через вызов хранимой процедуры
        /// </summary>
        /// <param name="query">хранимая процедура</param>
        /// <param name="parameters">коллекция параметров</param>
        /// <returns>Объект с данными</returns>
        public static SqlDataReader GetStorageProc(String storagerpoc, List<SqlParameter> parameters)
        {
            Command = new SqlCommand(storagerpoc, Connection);
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    Command.Parameters.Add(p);
                }
            }

            return Command.ExecuteReader();
        }

        /// <summary>
        /// Запись в базу используя параметры
        /// </summary>
        /// <param name="query">строка запроса</param>
        /// <param name="parameters">коллекция параметров</param>
        /// <returns></returns>
        public static int Exec(String query, List<SqlParameter> parameters)
        {
            Command = new SqlCommand(query, Connection);
            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    Command.Parameters.Add(p);
                }
            }

            return Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Запись в базу через вызов хранимой процедуры
        /// </summary>
        /// <param name="query">хранимая процедура</param>
        /// <param name="parameters">коллекция параметров</param>
        /// <returns></returns>
        public static int ExecStorageProc(String storageproc, List<SqlParameter> parameters)
        {
            Command = new SqlCommand(storageproc, Connection);
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    Command.Parameters.Add(p);
                }
            }

            return Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Выполение специальных встроенных функций SQL (min, max, count)
        /// </summary>
        /// <param name="query">строка запроса</param>
        /// <param name="parameters">коллекция параметров</param>
        /// <returns>результат работы</returns>
        public static int Scalar(String query, List<SqlParameter> parameters)
        {
            Command = new SqlCommand(query, Connection);

            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    Command.Parameters.Add(p);
                }
            }

            return (int)Command.ExecuteScalar();
        }
    }
}
