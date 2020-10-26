using System.Xml;

namespace BusinessLogicLayer
{
    public class XMLController
    {
        public XmlReader GetXMLFile(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            reader.Close();
            return reader;
        }
    }
}
