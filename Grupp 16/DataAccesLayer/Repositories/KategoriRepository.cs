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

        public void New(Kategori kategori)
        {
            kategoriList.Add(kategori);
            SaveAllChanges();
        }

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

        public void Delete(int index)
        {
            try
            {
                kategoriList.RemoveAt(index);
                SaveAllChanges();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        public void SaveAllChanges()
        {
            categoryDataManager.Serialize(kategoriList);
        }

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

        public Kategori GetByNamn(string namn)
        {
            return GetAll().FirstOrDefault(p => p.Namn.Equals(namn));
        }

        public string GetName(int index)
        {
            return kategoriList[index].Namn;
        }
    }
}
