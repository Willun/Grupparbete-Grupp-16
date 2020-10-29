using System;
using System.Collections.Generic;

namespace Models
{
    public class Podcast
    {
        public string Url { get; set; }
        public int Avsnitt { get; set; }
        public string Namn { get; set; }
        public double Frekvens { get; set; }
        public string Kategori { get; set; }
        public string UpdateFrequency { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Episode> episodeList { get; set; }

        public Podcast(string url, int avsnitt, string namn, double frekvens, string kategori, List<Episode> episodes)
        {
            Url = url;
            Avsnitt = avsnitt;
            Namn = namn;
            Frekvens = frekvens;
            Kategori = kategori;
            episodeList = episodes;
        }

        public Podcast()
        {

        }

        public bool NeedsUpdate
        {
            get
            {
                return LastUpdated <= DateTime.Now;
            }
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
