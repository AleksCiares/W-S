using System;

namespace OneByteCaps.WebUtility.HttpRequest
{
    internal abstract class HttpRequester
    {
        protected abstract WebPage? RequestWebPage(String url);
        internal WebPage? GetWebPage(String url) => RequestWebPage(url);


        /*        protected HttpRequester(ref String? baseUrl) 
                {
                    if(baseUrl is null) throw new ArgumentNullException(nameof(baseUrl));
                    _baseUrl= baseUrl;
                    _urls = new Queue<string>();
                    _urls.Enqueue(_baseUrl);
                    _urlsHandler = new AutoResetEvent(true);
                }
                internal void AddUrlToScrape(ref String? url)
                {
                    if (url is null) return;
                    _urlsHandler!.WaitOne();
                    _urls!.Enqueue(url);
                    _urlsHandler!.Set();
                }
                internal WebPage? GetWebPage()
                {
                    _urlsHandler!.WaitOne();
                    if (_urls!.Count <= 0) {
                        _urlsHandler!.Set();
                        return null;
                    }
                    String tempUrl = _urls.Dequeue();
                    _urlsHandler!.Set();
                    return RequestWebPage(ref tempUrl!);
                }*/

        /*        private Queue<String>? _urls;
                private AutoResetEvent? _urlsHandler;
                private String? _baseUrl; */
    }
}
