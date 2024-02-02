using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice_8_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string filePath = projectDirectory + "\\xml\\notebook.xml";

            XDocument xmlDocument = new XDocument();
            XElement user = new XElement("Person");
            XElement addressElem = new XElement("Address");
            XElement phonesElem = new XElement("Phones");

            XAttribute nameAtr = GetXAttributeFromConsole("name", "Введите ФИО:");
            user.Add(nameAtr);
            XElement streetElem = GetXElementFromConsole("Street", "Введите улицу:");
            addressElem.Add(streetElem);
            XElement houseElem = GetXElementFromConsole("HouseNumber", "Введите номер дома:");
            addressElem.Add(houseElem);
            XElement flatElem = GetXElementFromConsole("FlatNumber", "Введите номер квартиры:");
            addressElem.Add(flatElem);
            user.Add(addressElem);
            XElement mobilePhoneElem = GetXElementFromConsole("MobilePhone", "Введите мобильный телефон:");
            phonesElem.Add(mobilePhoneElem);
            user.Add(phonesElem);
            XElement flatPhoneElem = GetXElementFromConsole("FlatPhone", "Введите домашний телефон:");
            phonesElem.Add(flatPhoneElem);

            xmlDocument.Add(user);
            xmlDocument.Save(filePath);
        }

        static XAttribute GetXAttributeFromConsole(string atrName, string message)
        {
            Console.WriteLine(message);
            string atrValue = Console.ReadLine();
            return new XAttribute(atrName, atrValue);
        }

        static XElement GetXElementFromConsole(string elemName, string message)
        {
            Console.WriteLine(message);
            string elemValue = Console.ReadLine();
            return new XElement(elemName, elemValue);
        }
    }
}
