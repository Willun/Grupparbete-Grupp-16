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
        Validation validation = new Validation();
        XMLController xMLController = new XMLController();

        public Form1()
        {
            InitializeComponent();
            showPodcast();
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

        public List<List<string>> GetPodcastAllEpisodesByXmlreader(XmlReader reader)
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
            Podcast curItem = (Podcast)listBoxShowPodcast.SelectedItem;
            System.Xml.XmlReader reader = xMLController.GetXMLFile(curItem.Url);
            List<List<string>> list = GetPodcastAllEpisodesByXmlreader(reader);

            foreach (var item in list)
            {
                foreach (var item1 in list)
                {
                    listBoxEpisodes.Items.Add(list);
                }
            }
        }
    }
}
