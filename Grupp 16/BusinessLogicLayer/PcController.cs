using DataAccesLayer.Repositories;
using Models;

namespace BusinessLogicLayer
{
    public class PcController
    {
        private IRepository<Podcast> podcastRepository;

        public PcController()
        {
            podcastRepository = new PcRepository();
        }

        public void CreatePodcast(string url, int avsnitt, string namn, int frekvens, string kategori, int antalAvsnitt)
        {

            Podcast podcast = new Podcast(url, avsnitt, namn, frekvens, kategori, antalAvsnitt);

            podcastRepository.Ny(podcast);
        }
    }
}
