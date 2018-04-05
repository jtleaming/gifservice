using System.Net.Http;
using System.Threading.Tasks;

namespace GifService.Common
{
    public class GifHttpClient : IGifHttpClient
    {
        private readonly HttpClient httpClient;
        public GifHttpClient()
        {
            httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return httpClient.GetAsync(uri);
        }
    }
    public interface IGifHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}