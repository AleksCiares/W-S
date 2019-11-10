using HtmlAgilityPack;
using System.Collections.Generic;

namespace WEB_Scraper
{
    interface IParser<T> 
        where T : class
    {
        List<T> Parse(HtmlDocument document, string xPathReq);
    }
}
