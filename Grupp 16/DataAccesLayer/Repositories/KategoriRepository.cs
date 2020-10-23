using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    class KategoriRepository
    {
        public class KategoriRepository : IKategoriRepository<Kategori>
        {
            DataManager dataManager;
            List<Kategori> kategoriList;

            public KategoriRepository()
            {
                kategoriList = new List<Kategori>();
                dataManager = new DataManager();
                kategoriList = GetAllK();
            }

            public void NyK(Kategori kategori)
            {
                kategoriList.Add(kategori);
                SaveAllChangesK();
            }

            public void SparaK(int index, Kategori kategori)
            {
                if (index >= 0)
                {
                    kategoriList[index] = kategori;
                }
                SaveAllChangesK();
            }

            public void TaBortK(int index)
            {
                kategoriList.RemoveAt(index);
                SaveAllChangesK();
            }

            public void SaveAllChangesK()
            {
                dataManager.SerializeK(kategoriList);
            }

            public List<Podcast> GetAllK()
            {
                List<Podcast> podcastListToBeReturned = new List<Podcast>();
                try
                {
                    podcastListToBeReturned = dataManager.Deserialize();
                }
                catch (Exception)
                {
                }
                return podcastListToBeReturned;
            }

            public Kategori GetByNamn(string namn)
            {
                return GetAllK().FirstOrDefault(p => p.Namn.Equals(namn));
            }

        }
    }
}
