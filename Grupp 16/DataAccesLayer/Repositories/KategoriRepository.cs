using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class KategoriRepository : IKategoriRepository<Kategori>
    {
        CategoryDataManager categoryDataManager;
        List<Kategori> kategoriList;

        public KategoriRepository()
        {
            kategoriList = new List<Kategori>();
            categoryDataManager = new CategoryDataManager();
            kategoriList = GetAll();
        }

        //Skapar ny katgori och sparar ändringarna
        public void New(Kategori kategori)
        {
            kategoriList.Add(kategori);
            SaveAllChanges();
        }

        //Sparar kategori ändringar
        public void Save(int index, Kategori kategori)
        {
            try
            {
                if (index >= 0)
                {
                    kategoriList[index] = kategori;
                }
                SaveAllChanges();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        //Raderar kategori och sparar ändringarna
        public void Delete(int index)
        {
            kategoriList.RemoveAt(index);
            SaveAllChanges();
        }

        //Sparar alla ändringar och lägger in dem i ett lokalt xml dokument
        public void SaveAllChanges()
        {
            categoryDataManager.Serialize(kategoriList);
        }

        //Hämtar alla kategorier från ett lokalt xml dokument 
        public List<Kategori> GetAll()
        {
            List<Kategori> kategoriListToBeReturned = new List<Kategori>();
            try
            {
                kategoriListToBeReturned = categoryDataManager.Deserialize();
            }
            catch (Exception)
            {
            }
            return kategoriListToBeReturned;
        }

        //Hämtar kategori via ett namn
        public Kategori GetByNamn(string namn)
        {
            return GetAll().FirstOrDefault(p => p.Namn.Equals(namn));
        }

        //Hämtar kategori via ett index
        public string GetName(int index)
        {
            return kategoriList[index].Namn;
        }
    }
}
