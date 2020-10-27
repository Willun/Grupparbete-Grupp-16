using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class PcController
    {
        EController eController = new EController();
        private IPcRepository<Podcast> podcastRepository;

        public PcController()
        {
            podcastRepository = new PcRepository();
        }

        public void CreatePodcast(string url, int avsnitt, string namn, int frekvens, string kategori)
        {
            List<Episode> episodes = eController.GetEpisodes(url);
            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori, episodes);
            podcastRepository.New(podcast);
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

        public Podcast GetPodcastByNameXXX(string name)
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
    }
}
