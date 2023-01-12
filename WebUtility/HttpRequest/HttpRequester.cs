namespace OneByteCaps.WebUtility.HttpRequest
{
    internal abstract class HttpRequester
    {
        protected HttpRequester(ref String url)
        {
            urls = new Queue<String>(1);
            urls.Enqueue(url);
        }
        internal abstract String? GetWebPage(ref String url);
        internal void AddUrlToScrape(ref String url) => urls.Enqueue(url);

        private Queue<String> urls;
    }
}
