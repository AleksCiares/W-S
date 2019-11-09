using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class HtmlLoader
    {
        public List<HtmlDocument> HtmlLoad(string baseUrl, int depth = 1)
        {
            List<HtmlDocument> documents = new List<HtmlDocument>();
            var webGet = new HtmlWeb();
            var document = webGet.Load(baseUrl);
            documents.Add(document);

           // var nodes = document.DocumentNode.CssSelect("*[href]");
            var nodes = document.DocumentNode.SelectNodes("//*[@href]");

            for(int i = 0; i < depth; i++)
            {
                try
                {
                    foreach (var node in nodes)
                    {
                        string url = node.Attributes["href"].Value;
                        if (url != null)
                        {
                            documents.Add(webGet.Load(url));
                            url = null;
                        }
                    }
                }
                catch (Exception ex)
                { }
                
            }

            return documents;
        }
    }
}
