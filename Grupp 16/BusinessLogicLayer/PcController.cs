using DataAccesLayer.Repositories;
using Models;

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

        public void CreatePodcast(string url, int avsnitt, string namn, int frekvens, string kategori, int antalAvsnitt)
        {
            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori, antalAvsnitt);
            podcastRepository.Ny(podcast);
        }

        public string GetPodcastAllaAvsnittByNamn(string namn)
        {
            Podcast podcast;
            podcast = podcastRepository.GetByNamn(namn);
            int antalAvsnitt = podcast.Avsnitt;
            for (int i = 0; i <= antalAvsnitt; i++)
            {
                string resultat += "";
            }
            return resultat;
        }
    }
}
