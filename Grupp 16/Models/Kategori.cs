namespace Models
{
    public class Kategori
    {
        public string Namn { get; set; }

        public Kategori(string namn)
        {
            Namn = namn;
        }

        public Kategori()
        {

        }

        private static readonly string[] standardKategorier = {
            @"Racing",
            @"Komedi",
            @"Mattematik",

        };

        public static string HamtaKategoriPath()
        {
            return KategoriPath;
        }
    }
}
