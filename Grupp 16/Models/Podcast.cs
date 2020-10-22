namespace Models
{
    public abstract class Podcast
    {
        public string Url { get; set; }
        public int Avsnitt { get; set; }
        public string Namn { get; set; }
        public int Frekvens { get; set; }
        public string Kategori { get; set; }
        public int AntalAvsnitt { get; set; }

        public Podcast(string url, int avsnitt, string namn, int frekvens, string kategori, int antalAvsnitt)
        {
            Url = url;
            Avsnitt = avsnitt;
            Namn = namn;
            Frekvens = frekvens;
            Kategori = kategori;
            AntalAvsnitt = antalAvsnitt;
        }
    }
}
