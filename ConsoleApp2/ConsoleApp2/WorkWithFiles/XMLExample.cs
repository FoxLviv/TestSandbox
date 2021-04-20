using System;
using System.Xml.Linq;

namespace LearnBasics.SandBox.WorkWithFiles
{
    class XMLExample
    {
        public void Example()
        {
            var createXdoc = new XDocument();
            // создаем первый элемент
            var iphone6 = new XElement("phone");
            // создаем атрибут
            var iphoneNameAttr = new XAttribute("name", "iPhone 6");
            var iphoneCompanyElem = new XElement("company", "Apple");
            var iphonePriceElem = new XElement("price", "40000");
            // добавляем атрибут и элементы в первый элемент
            iphone6.Add(iphoneNameAttr);
            iphone6.Add(iphoneCompanyElem);
            iphone6.Add(iphonePriceElem);

            // создаем второй элемент
            var galaxys5 = new XElement("phone");
            var galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            var galaxysCompanyElem = new XElement("company", "Samsung");
            var galaxysPriceElem = new XElement("price", "33000");
            galaxys5.Add(galaxysNameAttr);
            galaxys5.Add(galaxysCompanyElem);
            galaxys5.Add(galaxysPriceElem);
            // создаем корневой элемент
            var phones = new XElement("phones");
            // добавляем в корневой элемент
            phones.Add(iphone6);
            phones.Add(galaxys5);
            // добавляем корневой элемент в документ
            createXdoc.Add(phones);
            //сохраняем документ
            createXdoc.Save("phones.xml");

            var readXDoc = XDocument.Load("phones.xml");
            foreach (XElement phoneElement in readXDoc.Element("phones").Elements("phone"))
            {
                var nameAttribute = phoneElement.Attribute("name");
                var companyElement = phoneElement.Element("company");
                var priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
        }


    }
}
