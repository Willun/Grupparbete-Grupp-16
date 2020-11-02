using BusinessLogicLayer;
using Grupp16;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Grupp_16
{
    public partial class Form1 : Form
    {
        PcController pcController = new PcController();
        KController kController = new KController();
        EController eController = new EController();
        Validation validation = new Validation();
        Timer timer = new Timer();

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

                        textBoxName.Text = "";
                        textBoxUrl.Text = "";
                        comboBoxUpdateFrequency.Text = "";
                        comboBoxCategory.Text = "";

                        DialogResult dr = MessageBox.Show("You have added a new podcast!?",
                        "Delete Category", MessageBoxButtons.OK);
                        switch (dr)
                        {
                            case DialogResult.OK:
                                listBoxShowPodcast.Items.Clear();
                                showPodcast();
                                break;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Web request timed out!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Check if the url is in the right format!");
                }
            }
            else
            {
                MessageBox.Show("Check If every field is not empty!");
            }
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
                    MessageBox.Show("You havent choosen anything yet!");
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
                    MessageBox.Show("Check if the url is in the right format!");
                }
            }
            else
            {
                MessageBox.Show("Check If every field is not empty!");
            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            if (textBoxCategory.Text != "")
            {
                if (listBoxCategory.SelectedItems.Count == 1)
                {
                    int curKategori = listBoxCategory.SelectedIndex;
                    string curCategoryName = listBoxCategory.SelectedItem.ToString();
                    Kategori k = kController.CreateCategorySave(textBoxCategory.Text);
                    DialogResult dr = MessageBox.Show("Are you sure you want to delete the category and all the podcasts that has it as it's category?",
                    "Delete Category", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            pcController.DeletePodcastWhenDeleteingCategory(curCategoryName, textBoxCategory.Text);
                            kController.DeleteKategori(curKategori);

                            List<Kategori> kategoriList = kController.GetCategoryList();
                            comboBoxCategory.Items.Clear();
                            foreach (var item in kategoriList)
                            {
                                comboBoxCategory.Items.Add(item.Namn);
                            }
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
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("You havent choosen anything yet!");
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
                    textBoxName.Text = "";
                    textBoxUrl.Text = "";
                    comboBoxUpdateFrequency.Text = "";
                    comboBoxCategory.Text = "";
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
                    MessageBox.Show("You havent choosen anything yet!");
                }
            }
            catch (System.NullReferenceException SAT)
            {
                MessageBox.Show(SAT.ToString());
            }
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
                        MessageBox.Show("You havent choosen anything yet!");
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
                        MessageBox.Show("You have saved the change!");
                    }
                }
                else
                {
                    MessageBox.Show("You havent choosen anything yet!!");
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