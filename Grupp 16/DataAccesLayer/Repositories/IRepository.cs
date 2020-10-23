using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Ny(T entity);
        void Spara(int index, T entity);
        void TaBort(int index);
        void SaveAllChanges();
        List<T> GetAll();
    }
}
