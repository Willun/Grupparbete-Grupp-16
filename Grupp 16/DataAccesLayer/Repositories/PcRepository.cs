﻿using Models;
using System;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories
{
    public class PcRepository : IPcRepository<Podcast>
    {
        DataManager dataManager;
        List<Podcast> podcastList;
        //List<Episode> episodeList;

        public PcRepository()
        {
            podcastList = new List<Podcast>();
            episodeList = new List<Episode>();
            dataManager = new DataManager();
            podcastList = GetAll();
        }

        public void New(Podcast podcast)
        {
            podcastList.Add(podcast);
            SaveAllChanges();
        }

        public void Save(int index, Podcast podcast)
        {
            if (index >= 0)
            {
                podcastList[index] = podcast;
            }
            SaveAllChanges();
        }

        public void Delete(int index)
        {
            podcastList.RemoveAt(index);
            SaveAllChanges();
        }

        public void SaveAllChanges()
        {
            dataManager.Serialize(podcastList);
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podcastListToBeReturned = new List<Podcast>();
            try
            {
                podcastListToBeReturned = dataManager.Deserialize();
            }
            catch (Exception)
            {
            }
            return podcastListToBeReturned;
        }

        public Podcast GetByNamn(string namn)
        {
            Podcast pc = new Podcast();
            List<Podcast> podcasts = GetAll();
            foreach (var item in podcasts)
            {
                if (item.Namn.Equals(namn))
                {
                    pc = item;
                    break;
                }
            }
            return pc;
            //Podcast pc = GetAll().FirstOrDefault(p => p.Namn.Equals(namn));
        }

        //public void UpdateKategoriForPodcast(int chosenKategori, string newKategori)
        //{
        //    kategoriList[chosenKategori].Kategori = newKategori;
        //}

        public string GetName(int index)
        {
            return podcastList[index].Namn;
        }
    }
}
