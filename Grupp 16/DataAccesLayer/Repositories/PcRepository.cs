using Models;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public class PcRepository : IPcRepository<Podcast>
    {
        DataManager dataManager;
        List<Podcast> podcastList;

        public PcRepository()
        {
            podcastList = new List<Podcast>();
            dataManager = new DataManager();
        }

        public void Ny(Podcast podcast)
        {
            podcastList.Add(podcast);
            SaveAllChanges();
        }

        public void Spara(int index, Podcast podcast)
        {
            if (index >= 0)
            {
                podcastList[index] = podcast;
            }
            SaveAllChanges();
        }

        public void TaBort(int index)
        {
            podcastList.RemoveAt(index);
            SaveAllChanges();
        }

        public void SaveAllChanges()
        {
            dataManager.Serialize(podcastList);
        }
    }
}
