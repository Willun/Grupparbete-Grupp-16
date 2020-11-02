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
        PodcastValidation podcastValidation = new PodcastValidation();
        CategoryValidation categoryValidation = new CategoryValidation();
        Timer timer = new Timer();

        //Körs när pogrammet skapas
        public Form1()
        {
            InitializeComponent();
            showPodcast();
            InitializeTimer();
            SetPcList();
            foreach (var item in kController.GetCategoryList())
            {
                comboBoxCategory.Items.Add(item.Namn);
            }
            showCategory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Koden körs när du klickar på delete, Tar bort podcast
        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (podcastValidation.CheckIfSelected(listBoxShowPodcast) == false)
                {
                    int curPodcast = listBoxShowPodcast.SelectedIndex;
                    pcController.DeletePodcast(curPodcast);
                    listBoxEpisodes.Items.Clear();
                    listBoxShowPodcast.Items.Clear();
                    showPodcast();

                    textBoxName.Text = "";
                    textBoxUrl.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Visar podcasts i istBoxShowPodcast
        private void showPodcast()
        {
            foreach (var item in pcController.GetPCList())
            {
                listBoxShowPodcast.Items.Add("Name: " + item.Namn + "   Episodes: " + item.Avsnitt.ToString() + "   Frequency: every " + item.Frekvens.ToString() + " minutes   Category: " + item.Kategori);
            }
        }

        // Lägger till en ny podcast 
        private void buttonNew1_Click(object sender, EventArgs e)
        {
            try
            {
                if (podcastValidation.CheckIfTheInputIsEmpty(textBoxName.Text) == false)
                {
                    if (podcastValidation.CheckIfValidURL(textBoxUrl.Text) == false)
                    {
                        if (podcastValidation.CheckIfTheInputIsEmptyComboBox(comboBoxUpdateFrequency) == false)
                        {
                            if (podcastValidation.CheckIfTheInputIsEmptyComboBox(comboBoxCategory) == false)
                            {
                                int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                                pcController.CreatePodcastToXML(textBoxUrl.Text, textBoxName.Text, frekvens, comboBoxCategory.SelectedItem.ToString());

                                textBoxName.Text = "";
                                textBoxUrl.Text = "";

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
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Kör när du har klickat på en episode, den visar även beskrivningen på den episoden man har valt
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

        //Avmarkerar episode listbox
        private void deselectListBoxEpisodes()
        {
            listBoxEpisodes.ClearSelected();
        }

        //Avmarkerar podcast listbox
        private void deselectListBoxShowPodcast()
        {
            listBoxShowPodcast.ClearSelected();
        }

        //Avmarkerar podcast och categori listbox samt uppdaterar podcast listbox
        private void deselectListBoxCategory()
        {
            listBoxShowPodcast.Items.Clear();
            showPodcast();
            listBoxCategory.ClearSelected();
        }

        //
        private void listBoxShowPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (podcastValidation.CheckIfSelected(listBoxShowPodcast) == false)
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
                    comboBoxUpdateFrequency.SelectedIndex = comboBoxUpdateFrequency.FindStringExact(pc.Frekvens.ToString());
                    comboBoxCategory.SelectedIndex = comboBoxCategory.FindStringExact(pc.Kategori);
                }
                else
                {
                    MessageBox.Show("You havent choosen anything yet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Lägger in alla kategorier in i kategori listboxen
        private void showCategory()
        {
            foreach (var item in kController.GetCategoryList())
            {
                listBoxCategory.Items.Add(item.Namn);
            }
        }

        // Lägger till kategori när du klickar ny
        private void buttonNew2_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryValidation.CheckIfTheInputIsEmpty(textBoxCategory.Text) == false)
                {
                    if (categoryValidation.CheckIfItemInListAlreadyExists(kController.GetKategoriListStrings(), textBoxCategory.Text) == false)
                    {
                        listBoxCategory.Items.Clear();
                        kController.CreateCategory(textBoxCategory.Text);
                        comboBoxCategory.Items.Add(textBoxCategory.Text);
                        showCategory();
                        textBoxCategory.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tar bort kategori efter du har tryckt på radera knappen
        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryValidation.CheckIfSelected(listBoxCategory) == false)
                {
                    int curKategori = listBoxCategory.SelectedIndex;
                    DialogResult dr = MessageBox.Show("Are you sure you want to delete the category and all the podcasts that has it as it's category?",
                    "Delete Category", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            pcController.DeletePodcastWhenDeleteingCategory(textBoxCategory.Text);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Körs när du tryckt på en kategori i listbox
        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (categoryValidation.CheckIfSelected(listBoxCategory) == false)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sparar informationen efter du tryckt spara
        private void buttonSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (podcastValidation.CheckIfTheInputIsEmpty(textBoxName.Text) == false)
                {
                    if (podcastValidation.CheckIfValidURL(textBoxUrl.Text) == false)
                    {
                        if (podcastValidation.CheckIfTheInputIsEmptyComboBox(comboBoxUpdateFrequency) == false)
                        {
                            if (podcastValidation.CheckIfTheInputIsEmptyComboBox(comboBoxCategory) == false)
                            {
                                if (listBoxShowPodcast.SelectedItems.Count == 1)
                                {
                                    int frekvens = int.Parse(comboBoxUpdateFrequency.SelectedItem.ToString());
                                    int curPodcast = listBoxShowPodcast.SelectedIndex;
                                    Podcast pc = pcController.CreatePodcast(textBoxUrl.Text, textBoxName.Text, frekvens, comboBoxCategory.Text);
                                    pcController.SavePodcast(curPodcast, pc);
                                    listBoxShowPodcast.Items.Clear();
                                    showPodcast();

                                    listBoxEpisodes.Items.Clear();
                                    textBoxName.Text = "";
                                    textBoxUrl.Text = "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sparar din kategori efter du klickat på spara
        private void buttonSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryValidation.CheckIfTheInputIsEmpty(textBoxCategory.Text) == false)
                {
                    if (categoryValidation.CheckIfSelected(listBoxCategory) == false)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Avmarkerar podcasten
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

        //Avmarkerar kategorin
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCategory.Text = "";

            deselectListBoxCategory();
        }

        //Avmarkerar episoden
        private void button3_Click(object sender, EventArgs e)
        {
            deselectListBoxEpisodes();
        }

        //Lägger till i Interval så att den kan uppdatera 
        private void InitializeTimer()
        {
            timer.Interval = 60000;
            timer.Tick += Tiktok;
            timer.Start();
        }

        //Återskapar det som behövs efter uppdatering av podcast
        private void SetPcList()
        {
            int indexPc = listBoxShowPodcast.SelectedIndex;
            int indexC = listBoxCategory.SelectedIndex;
            listBoxShowPodcast.Items.Clear();
            var pcList = pcController.GetPCList();
            pcList.ToList().ForEach(podcast => listBoxShowPodcast.Items.Add("Name: " + podcast.Namn + "   Episodes: " + podcast.Avsnitt.ToString() + "   Frequency: every " + podcast.Frekvens.ToString() + " minutes   Category: " + podcast.Kategori));
            if (indexPc >= 0)
            {
                listBoxShowPodcast.SetSelected(indexPc, true);
            }
            if (indexC >= 0)
            {
                listBoxCategory.SetSelected(indexC, true);
            }
        }

        //Kollar och uppdaterar varje podcast
        private void Tiktok(object sender, EventArgs e)
        {
            foreach (var podcast in pcController.GetPCList().Where(p => p.NeedsToUpdate))
            {
                podcast.Update();
                SetPcList();
            }
        }
    }
}
