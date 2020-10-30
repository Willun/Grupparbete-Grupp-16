using BusinessLogicLayer;
using DataAccesLayer.Repositories;
using Grupp16;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //private Timer timer1 = new Timer();
        //int numberOfTimeUpdated = 0;

        int index = 0;

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

            //timer1.Interval = 1000;
            //timer1.Tick += Timer1_Tick;
            //timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void Timer1_Tick(object sender, EventArgs e)
        //{
        //    foreach (var podcast in pcRepository.GetAll())
        //    {
        //        if (podcast.NeedsUpdate)
        //        {
        //            podcast.Update();
        //            numberOfTimeUpdated++;
        //        }
        //    }
        //}

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            int curPodcast = listBoxShowPodcast.SelectedIndex;
            pcRepository.Delete(curPodcast);
            listBoxEpisodes.Items.Clear();
            listBoxShowPodcast.Items.Clear();
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
            foreach (var item in pcController.GetPCList())
            {
                listBoxShowPodcast.Items.Add("Name: " + item.Namn + "   Episodes: " + item.Avsnitt.ToString() + "   Frequency: every " + item.Frekvens.ToString() + " minutes   Category: " + item.Kategori);
            }
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxUrl.Text != null && comboBoxUpdateFrequency.SelectedItem != null && comboBoxCategory.SelectedItem != null)
            {
                if (validation.CheckIfValidURL(textBoxUrl.Text))
                {
                    try
                    {
                        //cts.CancelAfter(2500);
                        //Task asyncAddingFeed = new Task(() => AddNewFeedToPersistent(cts));
                        //asyncAddingFeed.Start();
                        //List<Episode> episodes = new List<Episode>();
                        int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                        pcController.CreatePodcast(textBoxUrl.Text, textBoxName.Text, frekvens, comboBoxCategory.SelectedItem.ToString());
                        listBoxShowPodcast.Items.Clear();
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
            if (listBoxEpisodes.SelectedItems.Count == 1)
            {
                listBoxEpisodeDescription.Items.Clear();
                //string episodeName = listBoxEpisodes.SelectedItem.ToString();
                //lableEpisodeDescription.Text = episodeName;
                int curPodcast = listBoxShowPodcast.SelectedIndex;
                string pcName = pcController.GetPcNameByIndex(curPodcast);
                Podcast pc = pcRepository.GetByNamn(pcName);

                string selectedEpisodeName = listBoxEpisodes.SelectedItem.ToString();
                List<Episode> episodes = eController.GetEpisodes(pc.Url);

                foreach (var item in episodes)
                {
                    if (selectedEpisodeName.Equals(item.Title))
                    {
                        listBoxEpisodeDescription.Items.Add(item.Description);
                    }
                }
            }
            else
            {
                listBoxEpisodeDescription.Items.Clear();
            }
            //listBoxEpisodeDescriptionViewer.Items.Clear();
            //int curEpisode = listBoxEpisodes.SelectedIndex;
            //int curEpisode1 = SelectedRow(curEpisode);
            //List<Episode> episodes = eController.GetEpisodes(pc.Url);

            //Populate the list here
            // Bind the list box according to the type of application you are using
            // here i use asp.net

            //try
            //{
            //    foreach (Episode episode in episodes)
            //    {
            //        if (episodes.Contains(curEpisode))
            //        {
            //            listBoxEpisodeDescriptionViewer.Items.Add(episode.Description);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error in clicking podcast!");
            //}


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
            //    listboxepisodedescriptionviewer.items.clear();
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
            listBoxShowPodcast.Items.Clear();
            showPodcast();
            listBoxCategory.ClearSelected();
        }

        private void listBoxShowPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxShowPodcast.SelectedItem != null)
                {
                    listBoxEpisodes.Items.Clear();
                    int curPodcast = listBoxShowPodcast.SelectedIndex;
                    string pcName = pcController.GetPcNameByIndex(curPodcast);
                    Podcast pc = pcController.GetPodcastByName(pcName);
                    //List<Episode> episodeList = pc.episodeList;
                    Console.WriteLine(pc.Namn + pc.Url + pc.episodeList.ToString());
                    foreach (var item in pc.episodeList)
                    {
                        listBoxEpisodes.Items.Add(item.Title);
                    }

                    listBoxCategory.ClearSelected();
                    textBoxName.Text = pc.Namn;
                    textBoxUrl.Text = pc.Url;
                    comboBoxUpdateFrequency.Text = pc.Frekvens.ToString();
                    comboBoxCategory.Text = pc.Kategori;
                }
                else
                {
                    MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
                }

            }
            catch (Exception)
            {

                throw;
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
                listBoxCategory.Items.Add(item.Namn);
            }
        }

        private void buttonNew2_Click(object sender, EventArgs e)
        {
            if (textBoxCategory.Text != "")
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
            if (textBoxCategory.Text != "")
            {
                if (listBoxCategory.SelectedItems.Count == 1)
                {
                    int curKategori = listBoxCategory.SelectedIndex;
                    Kategori k = kController.CreateCategorySave(textBoxCategory.Text);
                    List<Podcast> podcasts = pcRepository.GetAll();
                    List<Podcast> podcastsToDelete = new List<Podcast>();

                    foreach (var item in podcasts)
                    {
                        if (k.Namn.Equals(item.Kategori))
                        {
                            podcastsToDelete.Add(item);
                        }
                    }

                    if (podcastsToDelete.Count() >= 0)
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete the category and all the podcasts that has it as it's category?",
                        "Delete Category", MessageBoxButtons.YesNo);

                        switch (dr)
                        {
                            case DialogResult.Yes:
                                foreach (var item in podcastsToDelete)
                                {
                                    pcRepository.Delete(index);
                                    index++;
                                }

                                List<Kategori> kategoriList = kategoriRepository.GetAll();
                                foreach (var item in kategoriList)
                                {
                                    comboBoxCategory.Items.Add(item.Namn);
                                }
                                kategoriRepository.Delete(curKategori);
                                listBoxCategory.Items.Clear();
                                textBoxCategory.Text = "";
                                showCategory();
                                listBoxShowPodcast.Items.Clear();
                                showPodcast();
                                comboBoxCategory.Items.Clear();
                                index = 0;
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
                }
            }
        }
        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxCategory.SelectedItems.Count == 1)
                {
                    int curKategori = listBoxCategory.SelectedIndex;
                    string kName = kController.GetKNameByIndex(curKategori);
                    Kategori k = new Kategori();
                    k = kController.GetKategoriByNameWithoutAddingToListBox(kName);
                    //string curKategori = listBoxCategory.SelectedIndex.ToString();
                    //textBoxCategory.Text = curKategori;
                    List<Podcast> podcasts = pcRepository.GetAll();
                    textBoxCategory.Text = kName;
                    listBoxShowPodcast.Items.Clear();
                    listBoxEpisodes.Items.Clear();
                    foreach (var item in podcasts)
                    {
                        if (item.Kategori.Equals(k.Namn))
                        {
                            listBoxShowPodcast.Items.Add("Name: " + item.Namn + "   Episodes: " + item.Avsnitt.ToString() + "   Frequency: every " + item.Frekvens.ToString() + " minutes   Category: " + item.Kategori);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
                }
            }
            catch (System.NullReferenceException SAT)
            {
                MessageBox.Show(SAT.ToString());
            }
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxUrl.Text != null && comboBoxUpdateFrequency.SelectedItem != null && comboBoxCategory.SelectedItem != null)
            {
                try
                {
                    if (listBoxShowPodcast.SelectedItems.Count == 1)
                    {
                        int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                        int curPodcast = listBoxShowPodcast.SelectedIndex;
                        Podcast pc = pcController.CreatePodcastSave(textBoxUrl.Text, textBoxName.Text, frekvens, comboBoxCategory.Text);
                        pcRepository.Save(curPodcast, pc);
                        listBoxShowPodcast.Items.Clear();
                        showPodcast();

                        listBoxEpisodes.Items.Clear();
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
                catch (System.ArgumentOutOfRangeException EAS)
                {
                    MessageBox.Show(EAS.ToString());
                }
            }
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCategory.Text != "")
                {
                    if (listBoxCategory.SelectedItems.Count == 1)
                    {
                        int curKategori = listBoxCategory.SelectedIndex;
                        string curCategoryName = listBoxCategory.SelectedItem.ToString();
                        bool hasItems = false;
                        Kategori k = kController.CreateCategorySave(textBoxCategory.Text);
                        List<Podcast> podcasts = pcRepository.GetAll();
                        List<Podcast> podcastsToSave = new List<Podcast>();

                        List<Kategori> kategoriList = kategoriRepository.GetAll();
                        foreach (var item in kategoriList)
                        {
                            kategoriRepository.Save(curKategori, k);
                            comboBoxCategory.Items.Add(item.Namn);
                        }

                        foreach (var item in podcasts)
                        {
                            if (curCategoryName.Equals(item.Kategori))
                            {
                                podcastsToSave.Add(item);
                                hasItems = true;
                            }
                        }

                        if (hasItems)
                        {
                            foreach (var item in podcastsToSave)
                            {
                                //Podcast pc = pcController.CreatePodcastSave(textBoxUrl.Text, 100, textBoxName.Text, frekvens, k.Namn);
                                //item.Kategori = k.Namn;
                                //pcRepository.Save(index, item);
                                //pcController.UpdatePodcastCategory(item.Kategori, k.Namn);
                                foreach (var podcast in pcController.GetPCList())
                                {
                                    if (podcast.Kategori.Equals(item.Kategori))
                                    {
                                        Podcast pc = pcController.CreatePodcastSave(podcast.Url, podcast.Namn, podcast.Frekvens, k.Namn);
                                        int i = pcController.GetPCList().IndexOf(podcast);
                                        pcRepository.Save(i, pc);
                                    }
                                }
                            }

                            kategoriRepository.Save(curKategori, k);
                            listBoxCategory.Items.Clear();
                            textBoxCategory.Text = "";
                            showCategory();
                            listBoxShowPodcast.Items.Clear();
                            showPodcast();
                            comboBoxCategory.Items.Clear();
                        }
                        else
                        {
                            MessageBox.Show("You have saved the change and no podcast was ...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Du har inte valt någonting, eller så har du valt fler än en sak!");
                }
            }
            catch (System.ArgumentOutOfRangeException AOORE)
            {
                MessageBox.Show(AOORE.ToString());
            }
            catch (System.InvalidOperationException IOE)
            {
                MessageBox.Show(IOE.ToString());
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
            listBoxEpisodes.Items.Clear();
            listBoxEpisodeDescription.Items.Clear();

            textBoxName.Text = "";
            textBoxUrl.Text = "";
            comboBoxUpdateFrequency.Text = "";
            comboBoxCategory.Text = "";

            deselectListBoxShowPodcast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCategory.Text = "";

            deselectListBoxCategory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deselectListBoxEpisodes();
        }

        private void listBoxEpisodeDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

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