using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_Scraper
{
    class Model
    {
        private string _url;
        private string _selector;
        private string _attrname;

        public IEnumerable<string> Parse()
        {
            List<string> hRefTags = new List<string>();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(_url);
            foreach (IElement element in document.QuerySelectorAll(_selector)) // selector "a"
            {
                hRefTags.Add(element.GetAttribute(_attrname)); // attrname "href"
            }

            return hRefTags;
        }
    }
}
