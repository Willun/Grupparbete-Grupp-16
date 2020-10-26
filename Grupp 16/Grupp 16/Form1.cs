using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;

namespace Grupp_16
{
    public partial class Form1 : Form
    {
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
            XmlReader reader = XmlReader.Create("https://rss.art19.com/impaulsive-with-logan-paul");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Console.WriteLine("--- Title: " + feed.Title.Text);
            Console.WriteLine("--- Description:" + feed.Description.Text);
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine(item.Title.Text);
            }
        }

        private void listBoxMediaViewer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
