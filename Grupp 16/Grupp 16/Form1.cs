using BusinessLogicLayer;
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
        Validation validation = new Validation();
        Timer timer = new Timer();


        int index = 0;

        public Form1()
        {
            InitializeComponent();
            showPodcast();
            showCategory();
            InitializeTimer();
            SetPcList();

            List<Kategori> kategori = kController.GetCategoryList();
            kController.GetCategoryList();
            foreach (var item in kategori)
            {
                comboBoxCategory.Items.Add(item.Namn);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            int curPodcast = listBoxShowPodcast.SelectedIndex;
            pcController.DeletePodcast(curPodcast);
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
                        int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                        pcController.CreatePodcast(textBoxUrl.Text, textBoxName.Text, frekvens, comboBoxCategory.SelectedItem.ToString());
                        listBoxShowPodcast.Items.Clear();
                        showPodcast();

                        textBoxName.Text = "";
                        textBoxUrl.Text = "";
                        comboBoxUpdateFrequency.Text = "";
                        comboBoxCategory.Text = "";

                        //Application.Restart();
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
                int curPodcast = listBoxShowPodcast.SelectedIndex;
                string pcName = pcController.GetPcNameByIndex(curPodcast);
                Podcast pc = pcController.GetPodcastByName(pcName);

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
                    List<Podcast> podcasts = pcController.GetPCList();
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
                                    pcController.DeletePodcast(index);
                                    index++;
                                }

                                List<Kategori> kategoriList = kController.GetCategoryList();
                                comboBoxCategory.Items.Clear();
                                foreach (var item in kategoriList)
                                {
                                    comboBoxCategory.Items.Add(item.Namn);
                                }
                                kController.DeleteKategori(curKategori);
                                listBoxCategory.Items.Clear();
                                textBoxCategory.Text = "";
                                showCategory();
                                listBoxShowPodcast.Items.Clear();
                                showPodcast();
                                comboBoxCategory.Items.Clear();
                                textBoxName.Text = "";
                                textBoxUrl.Text = "";
                                comboBoxUpdateFrequency.Text = "";
                                comboBoxCategory.Text = "";
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
                    Kategori k = new Kategori();
                    int curKategori = listBoxCategory.SelectedIndex;
                    string kName = kController.GetKNameByIndex(curKategori);
                    k = kController.GetKategoriByNameWithoutAddingToListBox(kName);
                    textBoxCategory.Text = kName;
                    listBoxShowPodcast.Items.Clear();
                    listBoxEpisodes.Items.Clear();
                    foreach (var item in pcController.GetPCList())
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
                        pcController.SavePodcast(curPodcast, pc);
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
                        Kategori k = kController.CreateCategorySave(textBoxCategory.Text);

                        kController.SaveCategory(curKategori, k);
                        pcController.UpdatePodcastCategory(curCategoryName, textBoxCategory.Text);
                        comboBoxCategory.Items.Add(k.Namn);

                        listBoxCategory.Items.Clear();
                        showCategory();
                        textBoxCategory.Text = "";
                        comboBoxCategory.Items.Clear();
                        foreach (var item in kController.GetCategoryList())
                        {
                            comboBoxCategory.Items.Add(item.Namn);
                        }
                        listBoxShowPodcast.Items.Clear();
                        showPodcast();
                        MessageBox.Show("You have saved the change and no podcast category was saved!");
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

        private void InitializeTimer()
        {
            try
            {
                timer.Interval = 60000;
                timer.Tick += Tiktok;
                timer.Start();
            }
            catch (System.NullReferenceException)
            {

                throw;
            }
        }

        private void SetPcList()
        {
            listBoxShowPodcast.Items.Clear();
            listBoxShowPodcast.Refresh();
            var pcList = pcController.GetPCList();
            pcList.ToList().ForEach(podcast => listBoxShowPodcast.Items.Add("Name: " + podcast.Namn + "   Episodes: " + podcast.Avsnitt.ToString() + "   Frequency: every " + podcast.Frekvens.ToString() + " minutes   Category: " + podcast.Kategori));
        }

        private void Tiktok(object sender, EventArgs e)
        {
            foreach (var podcast in pcController.GetPCList().Where(p => p.NeedsToUpdate))
            {
                if (pcController.GetIfANewEpisodeIsOut(podcast, podcast.Url) == true)
                {
                    podcast.Update();
                    SetPcList();
                }
            }
        }
    }
}