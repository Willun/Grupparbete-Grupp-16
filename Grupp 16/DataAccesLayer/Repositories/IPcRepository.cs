using Models;

namespace DataAccesLayer.Repositories
{
    public interface IPcRepository<T> : IRepository<T> where T : Podcast
    {
        T GetByUrl(string url);
        T GetByUppdateringsfrekvens(int uf);
        T GetByKategori(string kategori);
    }
}
