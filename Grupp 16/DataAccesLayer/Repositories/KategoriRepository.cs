using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class KategoriRepository : IKategoriRepository<Kategori>
    {
        DataManager dataManager;
        List<Kategori> kategoriList;

        public KategoriRepository()
        {
            kategoriList = new List<Kategori>();
            dataManager = new DataManager();
            kategoriList = GetAll();
        }

        public void New(Kategori kategori)
        {
            kategoriList.Add(kategori);
            SaveAllChanges();
        }

        public void Save(int index, Kategori kategori)
        {
            if (index >= 0)
            {
                kategoriList[index] = kategori;
            }
            SaveAllChanges();
        }

        public void Delete(int index)
        {
            kategoriList.RemoveAt(index);
            SaveAllChanges();
        }

        public void SaveAllChanges()
        {
            dataManager.SerializeK(kategoriList);
        }

        public List<Kategori> GetAll()
        {
            List<Kategori> kategoriListToBeReturned = new List<Kategori>();
            try
            {
                kategoriListToBeReturned = dataManager.DeserializeK();
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
    }
}
