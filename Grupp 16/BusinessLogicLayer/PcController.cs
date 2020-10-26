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

        public string GetPodcastByName(string namn)
        {
            Podcast podcast = podcastRepository.GetByNamn(namn);
            string podcasten = podcast.Avsnitt.ToString() + "   " + podcast.Namn + "   " + "Var " + podcast.Frekvens.ToString() + ":e " + "minut" + "   " + podcast.Kategori;
            return podcasten;
        }



        //public static Dictionary<string, string> GetEpisodeDescription(string filplats)
        //{
        //    Dictionary<string, string> episode = new Dictionary<string, string>();
        //    string korrigeradBeskrivning;
        //    XmlDocument dokument = HamtaXMLDokument(filplats);
        //    XmlNodeList titlar = dokument.SelectNodes("//rss/channel/item/title");
        //    XmlNodeList beskrivningar = dokument.SelectNodes("//rss/channel/item/description");
        //    for (int i = 0; i < titlar.Count; i++)
        //    {
        //        korrigeradBeskrivning = Regex.Replace(beskrivningar[i].InnerText, @"<.*?>", "");
        //        episode.Add(titlar[i].InnerText, korrigeradBeskrivning);
        //    }
        //    return episode;
        //}
    }
}
