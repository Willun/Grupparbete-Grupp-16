﻿using BusinessLogicLayer;
using DataAccesLayer.Repositories;
using Grupp16;
using Models;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;

namespace Grupp_16
{
    public partial class Form1 : Form
    {
        PcController pcController = new PcController();
        KController kController = new KController();
        EController eController = new EController();
        PcRepository pcRepository = new PcRepository();
        KategoriRepository kategoriRepository = new KategoriRepository();
        Validation validation = new Validation();

        private Timer timer1 = new Timer();
        int numberOfTimeUpdated = 0;

        public Form1()
        {
            InitializeComponent();
            showPodcast();
            showCategory();
            List<Kategori> kategori = kategoriRepository.GetAll();
            foreach (var item in kategori)
            {
                comboBoxCategory.Items.Add(item.Namn);
            }

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var podcast in pcRepository.GetAll())
            {
                if (podcast.NeedsUpdate)
                {
                    podcast.Update();
                    numberOfTimeUpdated++;
                }
            }
        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            int curPodcast = listBoxShowPodcast.SelectedIndex;
            pcRepository.Delete(curPodcast);
            listBoxShowPodcast.Items.Clear();
            listBoxEpisodes.Items.Clear();
            showPodcast();

            textBoxName.Text = "";
            textBoxUrl.Text = "";
            comboBoxUpdateFrequency.Text = "";
            comboBoxCategory.Text = "";
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void showPodcast()
        {
            foreach (var item in pcController.GetPodcastList())
            {
                listBoxShowPodcast.Items.Add(pcController.GetPodcastByName(item.Namn));
            }
        }


        private void buttonNew1_Click(object sender, EventArgs e)
        {
            if (textBoxUrl.Text != null && comboBoxUpdateFrequency.SelectedItem != null && comboBoxCategory.SelectedItem != null)
            {
                if (validation.CheckIfValidFeed(textBoxUrl.Text))
                {
                    try
                    {
                        listBoxShowPodcast.Items.Clear();
                        int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                        //cts.CancelAfter(2500);
                        //Task asyncAddingFeed = new Task(() => AddNewFeedToPersistent(cts));
                        //asyncAddingFeed.Start();
                        List<Episode> episodes = new List<Episode>();
                        pcController.CreatePodcast(textBoxUrl.Text, 100, textBoxName.Text, frekvens, comboBoxCategory.SelectedItem.ToString());
                        showPodcast();

                        textBoxName.Text = "";
                        textBoxUrl.Text = "";
                        comboBoxUpdateFrequency.Text = "";
                        comboBoxCategory.Text = "";
                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Web request timed out! Det tog för lång tid.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Försäkra dig om att URL:en är korrekt formaterad!");
                }
            }
            else
            {
                MessageBox.Show("Försäkra du har fyllt i alla fält!");
            }
            //string xmlreader = PcController.GetUrlFromInternet();
            //pcController.CreatePodcast();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public List<List<string>> GetPodcastAllEpisodes(XmlReader reader)
        {
            List<string> subject = new List<string>();
            List<string> summary = new List<string>();
            List<List<string>> text = new List<List<string>>();

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                subject.Add(item.Title.Text);
                summary.Add(item.Summary.Text);
            }

            text.Add(subject);
            text.Add(summary);

            return text;
        }

        private void listBoxEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxEpisodeDescriptionViewer.Items.Clear();
            int curPodcast = listBoxShowPodcast.SelectedIndex;
            string pcName = pcController.GetPcNameByIndex(curPodcast);
            Podcast pc = pcController.GetPodcastByNameWithoutAddingToListBox(pcName);
            //PopulateTextBoxes();
            List<Episode> episodes = eController.GetEpisodes(pc.Url);
            try
            {
                foreach (Episode episode in episodes)
                {
                    listBoxEpisodeDescriptionViewer.Items.Add(episode.Description);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in clicking podcast!");
            }


            //if (listBoxEpisodes.SelectedItems.Count == 1)
            //{
            //    int curPodcast = listBoxShowPodcast.SelectedIndex;
            //    string curEpisode = listBoxEpisodes.SelectedIndex.ToString();
            //    string pcName = pcController.GetPcNameByIndex(curPodcast);
            //    Podcast pc = pcController.GetPodcastByNameWithoutAddingToListBox(pcName);

            //    List<Episode> episodes = eController.GetEpisodes(pc.Url);
            //    int index = episodes.FindIndex(a => a.ToString() == curEpisode);
            //    Episode episode = episodes[index];

            //    foreach (var item in episodes)
            //    {
            //        if (item.Title.Equals(episode))
            //        {
            //            listBoxEpisodeDescriptionViewer.Items.Add(item.Description);
            //        }
            //    }
            //}
            //else
            //{
            //    listBoxEpisodeDescriptionViewer.Items.Clear();
            //}



            //if (listboxshowpodcast.selecteditems.count == 1)
            //{
            //    int eindex = listboxepisodes.selectedindex;
            //    int feedindex = listboxshowpodcast.selecteditems[0].;
            //    string description = entitetslogik.hamtaavsnittsbeskrivning(feedindex, episodeindex);
            //    populator.uppdateralista(avsnittsbeskrivningtextruta, description);
            //}
            //else
            //{
            //    avsnittsbeskrivningtextruta.clear();
            //}
        }

        private void deselectListBoxEpisodes()
        {
            listBoxEpisodes.ClearSelected();
        }

        private void deselectListBoxShowPodcast()
        {
            listBoxShowPodcast.ClearSelected();
        }

        private void deselectListBoxCategory()
        {
            listBoxCategory.ClearSelected();
        }

        private void listBoxShowPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowPodcast.SelectedItems.Count == 1)
            {
                listBoxEpisodes.Items.Clear();
                int curPodcast = listBoxShowPodcast.SelectedIndex;
                string pcName = pcController.GetPcNameByIndex(curPodcast);
                Podcast pc = pcController.GetPodcastByNameWithoutAddingToListBox(pcName);

                foreach (var item in pc.episodeList)
                {
                    listBoxEpisodes.Items.Add(item.Title);
                }

                textBoxName.Text = pc.Namn;
                textBoxUrl.Text = pc.Url;
                comboBoxUpdateFrequency.Text = pc.Frekvens.ToString();
                comboBoxCategory.Text = pc.Kategori;
            }
            else
            {
                MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
            }
            //listBoxEpisodes.Items.Clear();
            //int curPodcast = listBoxShowPodcast.SelectedIndex;
            //string pcName = pcController.GetPcNameByIndex(curPodcast);
            //Podcast pc = pcController.GetPodcastByNameWithoutAddingToListBox(pcName);

            //foreach (var item in pc.episodeList)
            //{
            //    listBoxEpisodes.Items.Add(item.Title);
            //}

            //textBoxName.Text = pc.Namn;
            //textBoxUrl.Text = pc.Url;
            //comboBoxUpdateFrequency.Text = pc.Frekvens.ToString();
            //comboBoxCategory.Text = pc.Kategori;
        }

        private void showCategory()
        {
            foreach (var item in kController.GetCategoryList())
            {
                listBoxCategory.Items.Add(kController.GetKategoriByName(item.Namn));
            }
        }

        private void buttonNew2_Click(object sender, EventArgs e)
        {
            if (textBoxCategory.Text != null)
            {
                if (validation.CheckIfItemInListAlreadyExists(kController.GetKategoriListStrings(), textBoxCategory.Text))
                {
                    try
                    {
                        listBoxCategory.Items.Clear();
                        //cts.CancelAfter(2500);
                        //Task asyncAddingFeed = new Task(() => AddNewFeedToPersistent(cts));
                        //asyncAddingFeed.Start();
                        kController.CreateCategory(textBoxCategory.Text);
                        comboBoxCategory.Items.Add(textBoxCategory.Text);
                        showCategory();
                        textBoxCategory.Text = "";

                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Web request timed out! Det tog för lång tid.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Försäkra dig om att URL:en är korrekt formaterad!");
                }
            }
            else
            {
                MessageBox.Show("Försäkra du har fyllt i alla fält!");
            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            int curKategori = listBoxCategory.SelectedIndex;
            kategoriRepository.Delete(curKategori);
            listBoxCategory.Items.Clear();
            textBoxCategory.Text = "";
            showCategory();
            comboBoxCategory.Items.Clear();
            List<Kategori> kategori = kategoriRepository.GetAll();
            foreach (var item in kategori)
            {
                comboBoxCategory.Items.Add(item.Namn);
            }
        }

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategory.SelectedItems.Count == 1)
            {
                int curKategori = listBoxCategory.SelectedIndex;
                string kName = kController.GetKNameByIndex(curKategori);
                Kategori k = kController.GetKategoriByNameWithoutAddingToListBox(kName);
                textBoxCategory.Text = k.Namn;
                //string curKategori = listBoxCategory.SelectedIndex.ToString();
                //textBoxCategory.Text = curKategori;
                List<Podcast> podcasts = pcRepository.GetAll();
                listBoxShowPodcast.Items.Clear();
                foreach (var item in podcasts)
                {
                    if (item.Kategori.Equals(k.Namn))
                    {
                        listBoxShowPodcast.Items.Add(item.Avsnitt.ToString() + "   " + item.Namn + "   " + "Var " + item.Frekvens.ToString() + ":e " + "minut" + "   " + item.Kategori);
                    }
                }
            }
            else
            {
                MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
            }
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (listBoxShowPodcast.SelectedItems.Count == 1)
            {
                int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                int curPodcast = listBoxShowPodcast.SelectedIndex;
                Podcast pc = pcController.CreatePodcastSave(textBoxUrl.Text, 100, textBoxName.Text, frekvens, comboBoxCategory.Text);
                pcRepository.Save(curPodcast, pc);
                listBoxShowPodcast.Items.Clear();
                showPodcast();

                textBoxName.Text = "";
                textBoxUrl.Text = "";
                comboBoxUpdateFrequency.Text = "";
                comboBoxCategory.Text = "";
            }
            else
            {
                MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
            }
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            if (listBoxCategory.SelectedItems.Count == 1)
            {
                int curKategori = listBoxShowPodcast.SelectedIndex;
                Kategori k = kController.CreateCategorySave(textBoxCategory.Text);
                kategoriRepository.Save(curKategori, k);
                listBoxCategory.Items.Clear();
                showCategory();
            }
            else
            {
                MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
            }
        }

        private void listBoxViewer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deselectListBoxShowPodcast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deselectListBoxCategory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deselectListBoxEpisodes();
        }

        //private void buttonSave1_Click(object sender, EventArgs e)
        //{
        //    if (listPodcast.SelectedItems.Count == 1)
        //    {
        //        int selectedFeed = listPodcast.SelectedItems[0].Index;
        //        EntitetsLogik.UppdateraFrekvensIntervall(selectedFeed, boxUppdatering.Text);
        //        EntitetsLogik.UppdateraFeedKategori(selectedFeed, boxKategori.Text);
        //        List<ListViewItem> persistentFeedList = EntitetsLogik.SkickaFeedsTillPoddlista();
        //        Populator.UppdateraListView(listPodcast, persistentFeedList);
        //        EntitetsLogik.SkickaFeedListaTillFil();
        //        Populator.UppdateraValda(listPodcast, listKategori, listAvsnitt, avsnittsBeskrivningTextruta, PodcastTitel);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
        //    }
        //}

        //private void buttonSave2_Click(object sender, EventArgs e)
        //{
        //    string newName = textBoxCategory.Text;
        //    Kategori kategori = (Kategori)listBoxCategory.SelectedItem;
        //    listBoxCategory.Items.Clear();
        //    kategori.cre
        //}
    }
}