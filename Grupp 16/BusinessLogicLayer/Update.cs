namespace BusinessLogicLayer
{
    public class Update
    {
        public Update()
        {

        }

        //public bool NeedsUpdate(Podcast)
        //{
        //    get
        //    {
        //        return NextUpdate <= DateTime.Now;
        //    }
        //}

        //public void Update()
        //{
        //    NextUpdate = DateTime.Now.AddMinutes(Interval);
        //    XDocument urlDocument = new XDocument();

        //    {
        //        urlDocument = XDocument.Load(Url);
        //        Episodes = (from x in urlDocument.Descendants("item")
        //                    select new Episode
        //                    {
        //                        Name = x.Element("title").Value,
        //                        Description = x.Element("description").Value
        //                    }).ToList();
        //        Console.WriteLine("Next update is at " + NextUpdate);
        //        Console.WriteLine("Podcast: " + Name + " updated at " + DateTime.Now);
        //    };
        //    CountEpisodes();
        //}
        //public bool[] CheckUpdate(PodcastList podcastList)
        //{
        //    bool[] updates = new bool[podcastList.Count];
        //    int counter = 0;

        //    foreach (Podcast item in podcastList)
        //    {
        //        updates[counter] = CheckInterval(item);
        //        counter++;
        //    }
        //    return updates;
        //}

        //public static bool CheckInterval(Podcast podcast)
        //{
        //    switch (podcast.UpdateFrequency)
        //    {
        //        case "10 sek":
        //            return podcast.LastUpdated.AddSeconds(10) < DateTime.Now.ToUniversalTime();
        //        case "1 min":
        //            return podcast.LastUpdated.AddMinutes(1) < DateTime.Now.ToUniversalTime();
        //        case "10 min":
        //            return podcast.LastUpdated.AddMinutes(10) < DateTime.Now.ToUniversalTime();
        //        case "1 h":
        //            return podcast.LastUpdated.AddHours(1) < DateTime.Now.ToUniversalTime();
        //        case "1 dag":
        //            return podcast.LastUpdated.AddDays(1) < DateTime.Now.ToUniversalTime();
        //        default:
        //            return false;
        //    }
        //}

        //public class LogicUpdateFreq
        //{
        //private int frekvens { get; set; }
        //private string url { get; set; }
        //public LogicUpdateFreq(string freqUrl, string frequence)
        //{
        //    frekvens = Convert.ToInt32(frequence);
        //    url = freqUrl;
        //    delay();
        //}
        //public async void UpdatePod()
        //{
        //    SyndicationFeed feed;
        //    feed = await RssHandler.ReadRss(url);
        //    var list = LogicPodcast.urlList;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (url.Equals(list[i]))
        //        {
        //            LogicPodcast.PodcastList[i] = feed;
        //            break;
        //        }
        //    }
        //    delay();
        //}

        //void delay()
        //{
        //    Task.Delay(TimeSpan.FromMinutes(frekvens)).ContinueWith(_ => UpdatePod());
        //}

    }
}

