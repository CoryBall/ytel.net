using System.Net.Http;

namespace Ytel
{
    public abstract class YtelBaseService
    {
        // ReSharper disable once InconsistentNaming
        protected readonly HttpClient _httpClient;

        protected YtelBaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}