using Models;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public interface IPcRepository<T> : IRepository<T> where T : Podcast
    {
        void SetPodcastList(List<Podcast> podcasts);
    }
}
