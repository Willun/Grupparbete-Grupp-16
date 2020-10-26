using BusinessLogicLayer;
using DataAccesLayer.Repositories;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupp_16
{
    public partial class Form1 : Form
    {
        PcController pcController = new PcController();
        PcRepository pcRepository = new PcRepository();
        Validation validation = new Validation();

        public Form1()
        {
            InitializeComponent();
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

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            if (textBoxUrl.Text != null && comboBoxUpdateFrequency.SelectedItem != null && comboBoxCategory.SelectedItem != null)
            {
                if (validation.CheckIfValidFeed())
                {
                    try
                    {
                        cts.CancelAfter(2500);
                        Task asyncAddingFeed = new Task(() => AddNewFeedToPersistent(cts));
                        asyncAddingFeed.Start();
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
            string xmlreader = PcController.GetUrlFromInternet();
            pcController.CreatePodcast();
        }

        private void listBoxMediaViewer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
