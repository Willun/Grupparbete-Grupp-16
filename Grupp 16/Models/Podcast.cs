namespace Models
{
    public abstract class Podcast
    {
        public string Avsnitt { get; set; }
        public string Namn { get; set; }
        public string Frekvens { get; set; }
        public string Kategori { get; set; }

        public Podcast(string avsnitt, string namn, string frekvens, string kategori)
        {
            Avsnitt = avsnitt;
            Namn = namn;
            Frekvens = frekvens;
            Kategori = kategori;
        }
    }
}
