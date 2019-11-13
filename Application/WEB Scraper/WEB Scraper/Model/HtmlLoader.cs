using HtmlAgilityPack;
using System.Collections.Generic;

namespace WEB_Scraper
{
    class HtmlLoader
    {
        public List<HtmlDocument> HtmlLoad(string baseUrl, int depth = 1)
        {
            List<HtmlDocument> documents = new List<HtmlDocument>();
            var webGet = new HtmlWeb();
            var document = webGet.Load(baseUrl);
            documents.Add(document);

            var nodes = document.DocumentNode.SelectNodes("//*[@href]");
            
            foreach (var node in nodes)
            {
                if (depth == 1)
                    break;

                string url = node.Attributes["href"].Value;
                if (url != null && !url.Contains(".css") && !url.Contains(".png") &&
                    url.Contains("https://") || url.Contains("http://"))
                {
                    document = webGet.Load(url);
                    if (document.ParsedText == null)
                        continue;

                    documents.Add(document);
                    --depth;
                }
            }

            return documents;
        }
    }
}
