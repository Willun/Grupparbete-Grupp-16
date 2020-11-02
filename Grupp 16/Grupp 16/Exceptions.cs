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

        // Kollar om du fyllt i något i listboxes
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

        // Kollar om comboboxen är empty
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

        // Kollar om URl är giltig
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

        // Kollar om itemet redan existerar
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

        // Kollar så du selectad något i din listbox
        public virtual bool CheckIfSelected(ListBox listbox)
        {
            if (listbox.SelectedIndex == -1)
            {
                throw (new Exception("Select a item in listbox!"));
            }
            else
            {
                return false;
            }
        }
    }
}
