using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("URL: ");
            string BaseUrl = Console.ReadLine();

            WebParser<string> WB = new WebParser<string>();
            HtmlLoader htmlLoader = new HtmlLoader();
            Data<string> data = new Data<string>();
            //List<HtmlDocument> documents = htmlLoader.HtmlLoad(BaseUrl);

            var webGet = new HtmlWeb();
            //var document = webGet.Load(BaseUrl);

            foreach (HtmlDocument document in htmlLoader.HtmlLoad(BaseUrl, 15))
            {
                data.StorageData(@"f:/scrapingData.txt",WB.Parse(document, ".post__title_link"));
            }

            /*
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage page = browser.NavigateToPage(new Uri(BaseUrl));
            var nodes = page.Html.CssSelect(".post__text");

            foreach (var node in nodes)
            {
                foreach (var a in node.Attributes.ToList())
                {
                    Console.WriteLine(a.Value);
                }
            }
            */

            Console.ReadLine();
        
        }

    }
}
