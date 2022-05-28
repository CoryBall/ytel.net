using System.Net.Http;

namespace Ytel
{
    public abstract class YtelBaseService
    {
        protected readonly HttpClient _httpClient;

        protected YtelBaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}