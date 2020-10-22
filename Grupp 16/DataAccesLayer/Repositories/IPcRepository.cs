using Models;

namespace DataAccesLayer.Repositories
{
    class IPcRepository
    {
        public interface IPersonRepository<T> : IRepository<T> where T : Podcast
        {
            T GetByName(string name);
        }
    }
}
