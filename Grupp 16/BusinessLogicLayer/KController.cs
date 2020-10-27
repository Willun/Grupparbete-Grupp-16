using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogicLayer
{
    public class KController
    {
        private IRepository<Kategori> kategoriRepository;

        public KController()
        {
            kategoriRepository = new KategoriRepository();
        }

        public void CreateCategory(string name)
        {
            Kategori kategori = new Kategori(name);
            kategoriRepository.New(kategori);
        }

        public List<Kategori> GetCategoryList()
        {
            return kategoriRepository.GetAll();
        }

        public List<string> GetKategoriListStrings()
        {
            List<string> kList = KategoriObjectToStringList();
            return kList;
        }

        public List<string> KategoriObjectToStringList()
        {
            List<Kategori> kObjects = new List<Kategori>();
            List<string> kStrings = (from o in kObjects select o.ToString()).ToList();
            return kStrings;
        }

        public string GetKategoriByName(string name)
        {
            Kategori kategori = kategoriRepository.GetByNamn(name);
            string kategorin = kategori.Namn;
            return kategorin;
        }

        public static void eraseFile(string filePath)
        {
            using (var stream = new FileStream(filPath, FileMode.Truncate, FileAccess.Write))
            {

            }
        }
    }
}
