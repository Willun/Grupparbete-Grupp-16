using DataAccesLayer.Repositories;
using Models;

namespace BusinessLogicLayer
{
    public class KController
    {
        private IRepository<Kategori> kategoriRepository;

        public KController()
        {
            kategoriRepository = new KategoriRepository();
        }

        public void CreateKategori(string name)
        {
            Kategori kategori = new Kategori(name);
        }
    }
}
