using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Models
{
    public class Podcast
    {
        public string Url { get; set; }
        public int Avsnitt { get; set; }
        public string Namn { get; set; }
        public int Frekvens { get; set; }
        public string Kategori { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Episode> episodeList { get; set; }

        public Podcast(string url, int avsnitt, string namn, int frekvens, string kategori, List<Episode> episodes)
        {
            Url = url;
            Avsnitt = avsnitt;
            Namn = namn;
            Frekvens = frekvens;
            Kategori = kategori;
            episodeList = new List<Episode>();
            episodeList = episodes;
            CountAllEpisodesInAList();
        }

        public Podcast()
        {

        }

        private void CountAllEpisodesInAList()
        {
            foreach (var i in episodeList)
            {
                Avsnitt++;
            }
        }

        public bool NeedsToUpdate
        {
            get
            {
                return LastUpdated <= DateTime.Now;
            }
        }

        public void Update()
        {
            LastUpdated = DateTime.Now.AddMinutes(Frekvens);
            XDocument urlDoc = new XDocument();

            {
                urlDoc = XDocument.Load(Url);
                episodeList = (from x in urlDoc.Descendants("item")
                               select new Episode
                               {
                                   Title = x.Element("title").Value,
                                   Description = x.Element("description").Value
                               }).ToList();
                Console.WriteLine("Update at " + LastUpdated);
                Console.WriteLine("Podcast: " + Namn + " updated at " + DateTime.Now);
            };
            CountAllEpisodesInAList();
        }

        //public string Update()
        //{
        //    LastUpdated = DateTime.Now.AddMinutes(Frekvens);
        //    return Namn + "'s Update() was invoked. Next update is at " + LastUpdated;
        //}

        public class PodcastList : List<Podcast>
        {
            public PodcastList()
            {

            }
        }
    }
}
