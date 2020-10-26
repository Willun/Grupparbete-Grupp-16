using DataAccesLayer.Repositories;
using Models;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

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

        public string GetPodcastByNamn(string namn)
        {
            Podcast podcast = podcastRepository.GetByNamn(namn);
            string podcasten = podcast.Avsnitt.ToString() + "   " + podcast.Namn + "   " + "Var " + podcast.Frekvens.ToString() + ":e " + "minut" + "   " + podcast.Kategori;
            return podcasten;
        }

        public string GetPodcastAllaAvsnittByNamn(string namn)
        {
            Podcast podcast = podcastRepository.GetByNamn(namn);
            int antalAvsnitt = podcast.Avsnitt;
            for (int i = 0; i <= antalAvsnitt; i++)
            {
                resultat += "Avsnitt #" + i + "/n";
            }
            return resultat;
        }

        public string GetPodcastAvsnittByNamn(string namn, string url)
        {
            var xmlStr = File.ReadAllText("Podcasts.xml");

            var str = XElement.Parse(xmlStr);

            var result = str.Elements("word").
            Where(x => x.Element("category").Value.Equals("verb")).ToList();
            //return result;
        }

        public void GetUrlFromInternet()
        {
            XmlReader reader = XmlReader.Create("https://rss.art19.com/impaulsive-with-logan-paul");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Console.WriteLine("--- Title: " + feed.Title.Text);
            Console.WriteLine("--- Description:" + feed.Description.Text);
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine(item.Title.Text);
            }
        }
    }
}
