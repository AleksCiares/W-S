using HtmlAgilityPack;
using System.Collections.Generic;

namespace Test
{
    interface IParser<T> 
        where T : class
    {
        List<T> Parse(HtmlDocument document, string xPathReq);
    }
}
