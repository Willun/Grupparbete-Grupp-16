using Models;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Ny(T podcast);
        void Spara(int index, Podcast podcast);
        void TaBort(int index);
        void SaveAllChanges();
        List<T> GetAll();
    }
}
