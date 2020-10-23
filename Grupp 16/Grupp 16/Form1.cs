using System;
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
            if(textBoxUrl.Text !=null && textBoxUrl.Text.Length>=3)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("logan.xml");
                
                foreach(XmlNode node in doc.DocumentElement)
                {
                    String name = node.Attributes[0].InnerText;
                    if(name== textBoxUrl.Text)
                    {
                        foreach(XmlNode child in node.ChildNodes)
                        {
                            listloda.Items.Add(child.InnerText);
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("invalid");
                textBoxUrl.Text= string.Empty;
                textBoxUrl.Focus();

            }
        }

        private void listBoxMediaViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
