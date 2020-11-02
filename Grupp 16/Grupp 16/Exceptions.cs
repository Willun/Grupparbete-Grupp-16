using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Syndication;
//using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace Grupp_16
{
    public class Exceptions : Exception
    {
        public Exceptions()
        {

        }

        public Exceptions(string messageText) :
            base(messageText)
        {

        }

        public Exceptions(string messageText, Exception inner) :
            base(messageText, inner)
        {

        }

        public virtual bool CheckIfTheInputIsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw (new Exception("Textbox is empty"));
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckIfTheInputIsEmptyComboBox(ComboBox cb)
        {
            if (cb.SelectedItem == null)
            {
                throw (new Exception("Combobox is empty"));
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckIfValidURL(string url)
        {
            try
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));
                foreach (SyndicationItem item in feed.Items)
                {
                    Debug.Print(item.Title.Text);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool CheckIfItemInListAlreadyExists(List<string> klist, string name)
        {
            if (klist.Contains(name) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
