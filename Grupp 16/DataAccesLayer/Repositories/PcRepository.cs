using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //Skapar en ny podcast och sparar ändringarna
        public void New(Podcast podcast)
        {
            podcastList = GetAll();
            podcastList.Add(podcast);
            SaveAllChanges();
        }

        //Sparar ändringarna
        public void Save(int index, Podcast podcast)
        {
            if (index >= 0)
            {
                podcastList[index] = podcast;
            }
            SaveAllChanges();
        }

        //Raderar podcast och sparar ändringarna
        public void Delete(int index)
        {
            podcastList.RemoveAt(index);
            SaveAllChanges();
        }

        //Sparar alla ändringar och lägger in dem i ett lokalt xml dokument
        public async void SaveAllChanges()
        {
            await Task.Run(() =>
            {
                podcastDataManager.Serialize(podcastList);
            });
        }

        //Hämtar alla podcasts från ett lokalt xml dokument 
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

        //Hämtar podcast via ett namn
        public Podcast GetByNamn(string namn)
        {
            return GetAll().First(p => p.Namn.Equals(namn));
        }

        //Hämtar podcast via ett index
        public string GetName(int index)
        {
            return GetAll()[index].Namn;
        }

        //Sätter podcastlistan till valfri lista
        public void SetPodcastList(List<Podcast> podcasts)
        {
            podcastList = podcasts;
        }
    }
}
