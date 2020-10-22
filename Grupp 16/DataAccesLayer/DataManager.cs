﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccesLayer
{
    public class DataManager
    {
        public void Serialize(List<Podcast> podcastList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podcastList.GetType());
            using (FileStream outFile = new FileStream("Podcast.xml", FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, podcastList);
            }
        }

        public List<Podcast> Deserialize()
        {
            List<Podcast> listOfPodcastsToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            using (FileStream inFile = new FileStream("Podcast.xml", FileMode.Open,
                FileAccess.Read))
            {
                listOfPodcastsToBeReturned = (List<Podcast>)xmlSerializer.Deserialize(inFile);
            }
            return listOfPodcastsToBeReturned;
        }
    }
}
