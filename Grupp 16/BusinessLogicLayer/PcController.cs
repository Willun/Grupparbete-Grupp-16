using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using static Models.Podcast;

namespace BusinessLogicLayer
{
    public class PcController
    {
        PcRepository pcRepository = new PcRepository();
        EController eController = new EController();
        private IPcRepository<Podcast> podcastRepository;

        List<string> urlList = new List<string>();
        private static PodcastList AllPodcastList = new PodcastList();
        private static PodcastList AllFilteredPodcastList = new PodcastList();

        public PcController()
        {
            podcastRepository = new PcRepository();
        }

        public void CreatePodcast(string url, int avsnitt, string namn, double frekvens, string kategori)
        {
            List<Episode> episodes = eController.GetEpisodes(url);
            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori, episodes);
            urlList.Add(podcast.Url);
            podcastRepository.New(podcast);
        }

        public Podcast CreatePodcastSave(string url, int avsnitt, string namn, double frekvens, string kategori)
        {
            List<Episode> episodes = eController.GetEpisodes(url);
            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori, episodes);
            return podcast;
        }

        public List<Podcast> GetPodcastList()
        {
            return podcastRepository.GetAll();
        }

        public string GetPodcastByName(string name)
        {
            Podcast podcast = podcastRepository.GetByNamn(name);
            string podcasten = podcast.Avsnitt.ToString() + "   " + podcast.Namn + "   " + "Var " + podcast.Frekvens.ToString() + ":e " + "minut" + "   " + podcast.Kategori;
            return podcasten;
        }

        public Podcast GetPodcastByNameWithoutAddingToListBox(string name)
        {
            Podcast podcast = podcastRepository.GetByNamn(name);
            return podcast;
        }

        public List<string> PodcastObjectToStringList()
        {
            List<Podcast> pcObjects = new List<Podcast>();
            List<string> pcStrings = (from o in pcObjects select o.ToString()).ToList();
            return pcStrings;
        }

        public string GetPcNameByIndex(int index)
        {
            return podcastRepository.GetName(index);
        }

        public static void UpdateFrequencyInterval(int chosenPodcast, string newUpdateFrequency)
        {
            AllPodcastList[chosenPodcast].UpdateFrequency = newUpdateFrequency;
        }

        public void UpdatePodcastCategory(string name, string newName)
        {
            List<Podcast> podcasts = pcRepository.GetAll();
            foreach (var item in podcasts)
            {
                if (name.Equals(item.Kategori))
                {
                    item.Kategori = newName;
                }
            }
            pcRepository.SetPodcastList(podcasts);
            pcRepository.SaveAllChanges();
        }

        public List<string> GetUrlList()
        {
            return urlList;
        }

        //public static bool KollaEfterUppdateringar()
        //{ // USE AS ASYNCHRONOUS TASK
        //    bool hasBeenUpdated = false;
        //    bool[] updateIntervalHasExpired = Update.CheckUpdate(AllPodcastList);
        //    for (int i = 0; i < AllPodcastList.Count; i++)
        //    {
        //        if (updateIntervalHasExpired[i] == true)
        //        {
        //            hasBeenUpdated = true;
        //            //string podcastURL = AllPodcastList[i].Url;
        //            //string pocastTitel = AllPodcastList[i].Namn;

        //            PcController.podcastRepository.Save(i, AllPodcastList[i]);

        //            AllPodcastList[i].AntalAvsnitt = HamtaAntalAvsnitt(XML.HamtaXMLFil(feedTitel));
        //            AllPodcastList[i].Avsnitt = HamtaAvsnitt(feedTitel);
        //            AllPodcastList[i].SenastUppdaterad = DateTime.Now.ToUniversalTime();
        //        }
        //    }
        //    return harUppdaterats;
        //}
    }
}
