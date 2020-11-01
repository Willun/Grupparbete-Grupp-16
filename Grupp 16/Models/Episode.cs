using System;
using System.Xml.Serialization;

namespace Models
{
    [Serializable, XmlRoot("Episodes")]
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Episode()
        {

        }
    }
}
