namespace BusinessLogicLayer
{
    class UpdatePodcast
    {

        public static string[] frequencyList =
        {
         "10 sek",
         "1 min",
         "10 min",
         "1 h",
         "1 dag"
        };

        public enum Frequency
        {
            sek,
            min,
            h,
            dag,
        }

        public static string GetFrequency(Frequency namn)
        {
            return frequencyList[(int)namn];
        }

        public static string[] GetFrequencys()
        {
            return frequencyList;
        }
    }
}
