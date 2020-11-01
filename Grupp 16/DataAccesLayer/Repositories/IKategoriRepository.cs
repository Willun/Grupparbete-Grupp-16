using Models;

namespace DataAccesLayer.Repositories
{
    public interface IKategoriRepository<T> : IRepository<T> where T : Kategori
    {

    }
}