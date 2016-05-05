using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Threading;

namespace Sunlight_WebDev_Evaulation__URLGenerator
{
    class GeneratedURL
    {
        public String URL { get { return _url.ToString().TrimEnd('-') + _domain.ToString(); } }
        private StringBuilder _url = new StringBuilder();
        private StringBuilder _domain = new StringBuilder();

        private String filePath = @"C:\Users\Arthur\Documents\visual studio 2015\Projects\Sunlight_WebDev_Evaulation__URLGenerator\Sunlight_WebDev_Evaulation__URLGenerator\Data\";

        public GeneratedURL(Random rand)
        {
            String fileContent = File.ReadAllText(filePath + "wordlist.xml");

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(fileContent);
            XmlNodeList wordList = xdoc.GetElementsByTagName("word");
            XmlNodeList domainList = xdoc.GetElementsByTagName("domain");

            //Random rand = new Random((int) DateTime.Now.Ticks & 0x000FFF);
            //Thread.Sleep(20);
            Int32 urlWordCount = rand.Next(2, 4);
            List<Int32> urlWord = new List<Int32>();

            for (int i = 0; i < urlWordCount; i++)
            {
                Int32 randTest = rand.Next(0, 100);
                while (urlWord.Contains(randTest))
                    randTest = rand.Next(0, 100);
                urlWord.Add(randTest);
            }

            foreach (Int32 wordReference in urlWord)
                _url.Append(wordList[wordReference].InnerText + "-");

            Int32 domainReference = rand.Next(0, 7);
            _domain.Append(domainList[domainReference].InnerText);
        }
    }
}
