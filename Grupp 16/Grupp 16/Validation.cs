using System;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Grupp16
{
    public class Validation
    {
        public bool CheckIfValidFeed()
        {
            string url = textBoxUrl.text;
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

        public bool CheckIfItemInListAlreadyExists(string NameList, string NameItem)
        {
            string nameList = NameList;
            if (nameList.Contains(NameItem) == true)
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
