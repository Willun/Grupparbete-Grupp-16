using System;

namespace Models
{
    public class Podcast
    {
        public string Url { get; set; }
        public int Avsnitt { get; set; }
        public string Namn { get; set; }
        public int Frekvens { get; set; }
        public string Kategori { get; set; }
        public int AntalAvsnitt { get; set; }
        public string UpdateFrequency { get; set; }
        public DateTime LastUpdated { get; set; }

        public Podcast(string url, int avsnitt, string namn, int frekvens, string kategori)
        {
            Url = url;
            Avsnitt = avsnitt;
            Namn = namn;
            Frekvens = frekvens;
            Kategori = kategori;
        }
        public Podcast()
        {

        }
    }
}
