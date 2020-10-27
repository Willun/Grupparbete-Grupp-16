using Models;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace BusinessLogicLayer
{
    class EController
    {
        public EController()
        {

        }

        public List<Episode> GetEpisodes(string Url)
        {
            var reader = XmlReader.Create(Url);
            var feed = SyndicationFeed.Load(reader);

            List<Episode> episodeList = new List<Episode>();

            foreach (var i in feed.Items)
            {
                Episode episode = new Episode();
                episode.Title = i.Title.Text;
                episode.Description = i.Summary.Text;
                episodeList.Add(episode);
            }

            return episodeList;
        }
    }
}
