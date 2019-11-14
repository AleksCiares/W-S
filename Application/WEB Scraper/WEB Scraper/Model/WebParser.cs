using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;


namespace WEB_Scraper
{
    class WebParser<T> : IParser<T>
        where T : class
    {
        public List<T> Parse(HtmlDocument document, string command)
        {
            if (document == null)
                return null;

            IEnumerable<HtmlNode> nodes;

            if (command.Contains("//"))
                nodes = document.DocumentNode.SelectNodes(command);
            else
                nodes = document.DocumentNode.CssSelect(command);

            if (nodes == null)
                return null;

            List<T> list = new List<T>();

            foreach(var item in nodes)
            {
                list.Add((T)Convert.ChangeType(item.InnerText, typeof(T)));
            }

            return list;
        }
    }
}

