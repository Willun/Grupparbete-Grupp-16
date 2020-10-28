//namespace BusinessLogicLayer
//{
//    public class Updater
//    {
//        public static bool[] CheckUpdate(FeedLista feedLista)
//        {

//            bool[] updates = new bool[feedLista.Count];
//            int counter = 0;

//            foreach (Podcast item in feedLista)
//            {
//                updates[counter] = compareinterval(item)
//                    counter++;

//            }
//            return updates;
//        }

//        public static bool CheckInterval(Podcast podcast)
//        {
//            switch (podcast.LastUpdated)
//            {
//                case "10 sek":
//                    return podcast.LastUpdated.AddSeconds(10) < DateTime.Now.ToUniversalTime();
//                case "30 sek":
//                    return podcast.LastUpdated.AddSeconds(30) < DateTime.Now.ToUniversalTime();
//                case "1 min":
//                    return podcast.LastUpdated.AddMinutes(1) < DateTime.Now.ToUniversalTime();
//                default:
//                    return false;
//            }
//        }
//    }
//}

