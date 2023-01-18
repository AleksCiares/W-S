

namespace OneByteCaps.WebUtility.HttpRequest
{
    internal sealed class WebClient : HttpRequester
    {
        internal static WebClient GetInstance()
        {
            if (_instance is null) {
                lock (_instanceLock) {
                    if(_instance is null)
                        _instance = new WebClient();
                }
            }
            return _instance;
        }

        protected override WebPage? RequestWebPage(string url)
        {
            
        }
        private WebClient() => _httpClient = new HttpClient();

        private HttpClient? _httpClient = null;
        private static volatile WebClient? _instance = null;
        private static readonly object _instanceLock = new object();
    }
}
