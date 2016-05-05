using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sunlight_WebDev_Evaulation__URLGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            String filePath = @"C:\Users\Arthur\Documents\visual studio 2015\Projects\Sunlight_WebDev_Evaulation__URLGenerator\Sunlight_WebDev_Evaulation__URLGenerator\Data\";

            List<GeneratedURL> urlList = new List<GeneratedURL>();
            Random rand = new Random((int)DateTime.Now.Ticks & 0x000FFF);

            for (int i = 0; i < 10; i++)
                urlList.Add(new GeneratedURL(rand));

            XElement xmlElements = new XElement("urls", urlList.Select(i => new XElement("url", i.URL)));
            xmlElements.Save(filePath + "generatedURL.xml");
        }
    }
}
