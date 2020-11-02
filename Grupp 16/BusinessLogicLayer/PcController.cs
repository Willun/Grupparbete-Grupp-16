using DataAccesLayer.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PcController
    {
        EController eController = new EController();
        IPcRepository<Podcast> podcastRepository;

        public PcController()
        {
            podcastRepository = new PcRepository();
        }

        public int AmountOfEpisodes(string url)
        {
            int amountOfEpisodes = eController.GetEpisodes(url).Count();
            return amountOfEpisodes;
        }

        public void DeletePodcast(int curPodcast)
        {
            podcastRepository.Delete(curPodcast);
        }

        public async void CreatePodcast(string url, string namn, int frekvens, string kategori)
        {
            await Task.Run(() =>
            {
                int amountOfEpisodes = AmountOfEpisodes(url);
                Podcast podcast = new Podcast(url, amountOfEpisodes, namn, frekvens, kategori, eController.GetEpisodes(url));
                podcastRepository.New(podcast);
            });
        }

        public Podcast CreatePodcastSave(string url, string namn, int frekvens, string kategori)
        {
            List<Episode> episodes = eController.GetEpisodes(url);
            int amountOfEpisodes = episodes.Count();
            Podcast podcast = new Podcast(url, amountOfEpisodes, namn, frekvens, kategori, episodes);
            return podcast;
        }

        public List<Podcast> GetPCList()
        {
            return podcastRepository.GetAll();
        }

        public Podcast GetPodcastByName(string name)
        {
            Podcast pc = podcastRepository.GetByNamn(name);
            return pc;
        }

        public string GetPcNameByIndex(int index)
        {
            return podcastRepository.GetName(index);
        }

        public void UpdatePodcastCategory(string name, string newName)
        {
            List<Podcast> podcasts = podcastRepository.GetAll();
            foreach (var item in podcasts)
            {
                if (name.Equals(item.Kategori))
                {
                    item.Kategori = newName;
                }
            }
            podcastRepository.SetPodcastList(podcasts);
            podcastRepository.SaveAllChanges();
        }

        public void DeletePodcastWhenDeleteingCategory(string pcName, string tbName)
        {
            List<Podcast> podcasts = podcastRepository.GetAll();
            foreach (var item in podcasts)
            {
                if (pcName.Equals(tbName))
                {
                    int index = podcasts.IndexOf(item);
                    podcastRepository.Delete(index);
                }
            }
        }

        public void SavePodcast(int index, Podcast pc)
        {
            podcastRepository.Save(index, pc);
        }

        public bool GetIfANewEpisodeIsOut(Podcast pc, string url)
        {
            bool aNewEpisodeIsOut = false;
            if (AmountOfEpisodes(url) > pc.Avsnitt)
            {
                aNewEpisodeIsOut = true;
            }
            else
            {
                aNewEpisodeIsOut = false;
            }
            return aNewEpisodeIsOut;
        }
    }
}
