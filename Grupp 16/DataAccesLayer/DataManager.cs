using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccesLayer
{
    public class DataManager
    {
        public void Serialize(List<Podcast> personList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(personList.GetType());
            using (FileStream outFile = new FileStream("Podcast.xml", FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, personList);
            }
        }

        public List<Person> Deserialize()
        {
            List<Person> listOfPersonsToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream inFile = new FileStream("Podcast.xml", FileMode.Open,
                FileAccess.Read))
            {
                listOfPersonsToBeReturned = (List<Person>)xmlSerializer.Deserialize(inFile);
            }
            return listOfPersonsToBeReturned;
        }
    }
}
