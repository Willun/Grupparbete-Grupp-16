using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class PcController
    {
        private IRepository<Podcast> podcastRepository;
        private string resultat;

        public PcController()
        {
            podcastRepository = new PcRepository();
        }

        public void CreatePodcast(string url, int avsnitt, string namn, int frekvens, string kategori)
        {
            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori);
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
    }
}
