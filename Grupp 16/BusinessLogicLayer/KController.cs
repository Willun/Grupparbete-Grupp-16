using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
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

        public Kategori CreateCategorySave(string name)
        {
            Kategori kategori = new Kategori(name);
            return kategori;
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

        public string GetKNameByIndex(int index)
        {
            return kategoriRepository.GetName(index);
        }

        public Kategori GetKategoriByNameWithoutAddingToListBox(string name)
        {
            Kategori k = kategoriRepository.GetByNamn(name);
            return k;
        }

        public void SaveCategory(int index, Kategori kategori)
        {
            kategoriRepository.Save(index, kategori);
        }

        public void DeleteKategori(int curKategori)
        {
            kategoriRepository.Delete(curKategori);
        }
    }
}