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

        //Returnerar antalet episoder
        public int AmountOfEpisodes(string url)
        {
            int amountOfEpisodes = eController.GetEpisodes(url).Count();
            return amountOfEpisodes;
        }

        //Raderar podcast
        public void DeletePodcast(int curPodcast)
        {
            podcastRepository.Delete(curPodcast);
        }

        //Skapar en ny podcast och returnerar den
        public Podcast CreatePodcast(string url, string namn, int frekvens, string kategori)
        {
            int amountOfEpisodes = AmountOfEpisodes(url);
            Podcast podcast = new Podcast(url, amountOfEpisodes, namn, frekvens, kategori, eController.GetEpisodes(url));
            return podcast;
        }

        //Skapar en podcast och lägger in den i ett xml dokument
        public async void CreatePodcastToXML(string url, string namn, int frekvens, string kategori)
        {
            await Task.Run(() =>
            {
                Podcast podcast = CreatePodcast(url, namn, frekvens, kategori);
                podcastRepository.New(podcast);
            });
        }

        //Hämtar podcast listan
        public List<Podcast> GetPCList()
        {
            return podcastRepository.GetAll();
        }

        //Hämtar podcast via ett namn
        public Podcast GetPodcastByName(string name)
        {
            Podcast pc = podcastRepository.GetByNamn(name);
            return pc;
        }

        //Hämtar podcast namn via ett index
        public string GetPcNameByIndex(int index)
        {
            return podcastRepository.GetName(index);
        }

        //Uppdaterar podcast kategori
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

        //Raderar alla podcasts med samma kategori som den du raderar 
        public void DeletePodcastWhenDeleteingCategory(string categoryName)
        {
            for (int i = GetPCList().Count() - 1; i >= 0; i--)
            {
                if (GetPCList()[i].Kategori.Equals(categoryName))
                {
                    podcastRepository.Delete(i);
                }
            }
        }

        //Spara podcast
        public void SavePodcast(int index, Podcast pc)
        {
            podcastRepository.Save(index, pc);
        }

        //Hämtar den nya episoden om en sådan har släppts
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
