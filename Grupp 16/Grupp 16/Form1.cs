using BusinessLogicLayer;
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
        PcRepository pcRepository = new PcRepository();
        KController kController = new KController();
        KategoriRepository kategoriRepository = new KategoriRepository();
        Validation validation = new Validation();
        XMLController xMLController = new XMLController();

        public Form1()
        {
            InitializeComponent();
            showPodcast();
            showCategory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {

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

        }

        private void listBoxShowPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curPodcast = listBoxShowPodcast.SelectedItem.ToString();
            Podcast pc = pcController.GetPodcastByNameXXX(curPodcast);
            foreach (var item in pc.episodeList)
            {
                ListViewItem listViewItem = new ListViewItem(item.ToString());
                listBoxEpisodes.Items.Add(listViewItem);
            }
            //XmlReader reader = xMLController.GetXMLFile(curPodcast.Url);
            //List<List<string>> list = GetPodcastAllEpisodesByXmlreader(reader);

            //foreach (var item in list)
            //{
            //    foreach (var item1 in list)
            //    {
            //        listBoxEpisodes.Items.Add(item1);
            //    }
            //}

            //try

            //{
            //    var podcastlist = pcController.GetPodcastList();
            //    foreach (var p in podcastlist)
            //    {
            //        listBoxShowPodcast(p.Namn, p.Kategori);
            //        Console.WriteLine(p.Namn, p.Kategori);
            //    };
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Fel!");
            //}
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
                        showCategory();
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