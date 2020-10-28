namespace BusinessLogicLayer
{
    class UpdatePodcast
    {

        public static string[] frekvenser =
        {
             "10 Sekunder"
             "30 Sekunder"
             "1 Minut"

        };

        public enum frekvens
        {
            sek,
            min,
        }

        public static string Getfrekvens(frekvens namn)
        {

            return frekvenserg[(int)namn];

        }


        public static string[] readfrekvens()
        {
            return frekvenser;
        }

    }
}
