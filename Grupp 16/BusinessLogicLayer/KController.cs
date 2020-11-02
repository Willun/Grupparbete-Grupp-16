using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class KController
    {
        private IKategoriRepository<Kategori> kategoriRepository;

        public KController()
        {
            kategoriRepository = new KategoriRepository();
        }

        //Skapar en kategori
        public void CreateCategory(string name)
        {
            Kategori kategori = new Kategori(name);
            kategoriRepository.New(kategori);
        }

        //Skapar och returnerar en kategori
        public Kategori CreateCategorySave(string name)
        {
            Kategori kategori = new Kategori(name);
            return kategori;
        }

        //Hämtar alla kategorier från kategorilistan
        public List<Kategori> GetCategoryList()
        {
            return kategoriRepository.GetAll();
        }

        //Returnerar en lista med strängar
        public List<string> GetKategoriListStrings()
        {
            List<string> kList = KategoriObjectToStringList();
            return kList;
        }

        //Lägger in kategoriobjekt i en sträng lista
        public List<string> KategoriObjectToStringList()
        {
            List<Kategori> kObjects = new List<Kategori>();
            List<string> kStrings = (from o in kObjects select o.ToString()).ToList();
            return kStrings;
        }

        //Hämtar kategorinamn från dess index
        public string GetKNameByIndex(int index)
        {
            return kategoriRepository.GetName(index);
        }

        //Hämtar kategorinamn från dess namn och returnerar det
        public Kategori GetKategoriByNameWithoutAddingToListBox(string name)
        {
            Kategori k = kategoriRepository.GetByNamn(name);
            return k;
        }

        //Sparar kategori
        public void SaveCategory(int index, Kategori kategori)
        {
            kategoriRepository.Save(index, kategori);
        }

        //Raderar kategori
        public void DeleteKategori(int curKategori)
        {
            kategoriRepository.Delete(curKategori);
        }
    }
}