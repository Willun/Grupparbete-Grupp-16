using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Grupp16
{
    public class Validation
    {
        public bool CheckIfValidFeed(string url)
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

        public bool CheckIfcomboBoxHasASelectedItem(string comboAndTextboxName)
        {
            if (string.IsNullOrEmpty(comboAndTextboxName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfItemInListAlreadyExists(List<string> klist, string name)
        {
            List<string> KListString = klist;
            if (KListString.Contains(name) == true)
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
