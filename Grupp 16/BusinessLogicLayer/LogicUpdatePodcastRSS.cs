using DataAccesLayer.Repositories;

namespace BusinessLogicLayer
{
    class LogicUpdatePodcastRSS
    {
        private int frekvens { get; set; }
        private string url { get; set; }

        PcController pcController = new PcController();
        XMLController xMLController = new XMLController();
        PcRepository pcRepository = new PcRepository();

        //public LogicUpdatePodcastRSS(string freqUrl, string frequence)
        //{
        //    frekvens = Convert.ToInt32(frequence);
        //    url = freqUrl;
        //    delay();
        //}

        //public async void UpdatePod()
        //{
        //    SyndicationFeed feed;
        //    feed = await xMLController.GetXMLFile(url);
        //    var list = pcController.GetUrlList();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (url.Equals(list[i]))
        //        {
        //            pcRepository.GetPodcastList = feed;
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
