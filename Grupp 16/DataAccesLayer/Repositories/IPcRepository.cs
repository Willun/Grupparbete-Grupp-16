using Models;

namespace DataAccesLayer.Repositories
{
    public interface IPcRepository<T> : IRepository<T> where T : Podcast
    {
        T GetByNamn(string namn);
    }
}
