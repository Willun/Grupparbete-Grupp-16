using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Grupp16
{
    public class Validation
    {
        public bool CheckIfValidURL(string url)
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

        public static bool OmKorrektXML(XmlDocument dokument)
        {
            if (dokument.ChildNodes.Count != 0)
            {
                return String.Equals(dokument.ChildNodes[1].Name.ToString(), "rss", StringComparison.OrdinalIgnoreCase);
            }
            else
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