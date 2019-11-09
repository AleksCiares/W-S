using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class WebParser<T>
        where T : class
    {
        public List<T> Parse(HtmlDocument document, string xPathReq)
        {
            var nodes = document.DocumentNode.CssSelect(xPathReq);
            List<T> list = new List<T>();

            foreach(var item in nodes)
            {
                list.Add((T)Convert.ChangeType(item.InnerText, typeof(T)));
            }

            return list;
        }
    }
}

