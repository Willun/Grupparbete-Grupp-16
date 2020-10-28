using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void New(T entity);
        void Save(int index, T entity);
        void Delete(int index);
        void SaveAllChanges();
        List<T> GetAll();
        T GetByNamn(string namn);
        string GetName(int index);
    }
}
