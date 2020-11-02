using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class PcRepository : IPcRepository<Podcast>
    {
        PodcastDataManager podcastDataManager;
        List<Podcast> podcastList;
        List<Episode> episodeList;

        public PcRepository()
        {
            podcastList = new List<Podcast>();
            episodeList = new List<Episode>();
            podcastDataManager = new PodcastDataManager();
            podcastList = GetAll();
        }

        public void New(Podcast podcast)
        {
            podcastList = GetAll();
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
            try
            {
                podcastList.RemoveAt(index);
                SaveAllChanges();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        public void SaveAllChanges()
        {
            podcastDataManager.Serialize(podcastList);
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podcastListToBeReturned = new List<Podcast>();
            try
            {
                podcastListToBeReturned = podcastDataManager.Deserialize();
            }
            catch (Exception)
            {

            }
            return podcastListToBeReturned;
        }

        public Podcast GetByNamn(string namn)
        {
            return GetAll().First(p => p.Namn.Equals(namn));
        }

        public string GetName(int index)
        {
            return GetAll()[index].Namn;
        }

        public void SetPodcastList(List<Podcast> podcasts)
        {
            podcastList = podcasts;
        }
    }
}
