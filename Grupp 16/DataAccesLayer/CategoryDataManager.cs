﻿using Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccesLayer
{
    class CategoryDataManager
    {
        //skapar en lista på kategorier i en XML-fil
        public void Serialize(List<Kategori> kategoriList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(kategoriList.GetType());
            using (FileStream outFile = new FileStream("Kategorier.xml", FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, kategoriList);
            }
        }

        //Läser listan med kategorier från xml-filen
        public List<Kategori> Deserialize()
        {
            List<Kategori> listOfKategorierToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Kategori>));
            using (FileStream inFile = new FileStream("Kategorier.xml", FileMode.Open,
                FileAccess.Read))
            {
                listOfKategorierToBeReturned = (List<Kategori>)xmlSerializer.Deserialize(inFile);
            }
            return listOfKategorierToBeReturned;
        }
    }
}
