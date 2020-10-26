using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class PcRepository : IPcRepository<Podcast>
    {
        DataManager dataManager;
        List<Podcast> podcastList;

        public PcRepository()
        {
            podcastList = new List<Podcast>();
            dataManager = new DataManager();
            podcastList = GetAll();
        }

        public void New(Podcast podcast)
        {
            podcastList.Add(podcast);
            SaveAllChanges();
        }

        public void Save(int index, Podcast podcast)
        {
            if (index >= 0)
            {
                podcastList[index] = podcast;
            }
            SaveAllChanges();
        }

        public void Delete(int index)
        {
            podcastList.RemoveAt(index);
            SaveAllChanges();
        }

        public void SaveAllChanges()
        {
            dataManager.Serialize(podcastList);
        }

        public List<Podcast> GetAll()
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

        public Podcast GetByNamn(string namn)
        {
            return GetAll().FirstOrDefault(p => p.Namn.Equals(namn));
        }
    }
}
