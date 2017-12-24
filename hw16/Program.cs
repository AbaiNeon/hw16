using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hw16
{
    class Program
    {
        static void Main(string[] args)
        {
            //firstTask();
            secondTask();

            Console.ReadLine();
        }

        static void firstTask()
        {
            List<Item> list1 = new List<Item>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://habrahabr.ru/rss/interesting/");

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode firstChild = xRoot.FirstChild;

            foreach (XmlNode xNode in firstChild)
            {
                if (xNode.Name == "item")
                {
                    string title = "";
                    string link = "";
                    string description = "";
                    string pubDate = "";

                    foreach (XmlNode childNode in xNode.ChildNodes)
                    {
                        if (childNode.Name == "title")
                            title = childNode.InnerText;

                        if (childNode.Name == "link")
                            link = childNode.InnerText;

                        if (childNode.Name == "description")
                            description = childNode.InnerText;

                        if (childNode.Name == "pubDate")
                            pubDate = childNode.InnerText;
                    }

                    list1.Add(new Item() { Title = title, Link = link, Description = description, PubDate = pubDate });
                }
            }
        }
        static void secondTask()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../Students.xml");

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "name")
                    {
                        Console.WriteLine("Имя: {0}", childnode.InnerText);
                    }
                    if (childnode.Name == "group")
                    {
                        Console.WriteLine("Группа: {0}", childnode.InnerText);
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine("Возраст: {0}", childnode.InnerText);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}