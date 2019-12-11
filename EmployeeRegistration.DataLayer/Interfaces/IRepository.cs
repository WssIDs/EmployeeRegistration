using System.Collections.Generic;

namespace EmployeeRegistration.DataLayer.Interfaces
{
    /// <summary>
    /// Интерфейс репозиториев
    /// </summary>
    /// <typeparam name="T">Cущность</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        T Get(int id);
        /// <summary>
        /// Добавить сущность
        /// </summary>
        void Create(T t);
        /// <summary>
        /// Обновить сущность
        /// </summary>
        void Update(T t);
        /// <summary>
        /// Удалить сущность по идентификатору
        /// </summary>
        void Delete(int id);
    }
}
