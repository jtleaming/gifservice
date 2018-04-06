using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GifService.Common;
using Newtonsoft.Json.Linq;

namespace GifService
{
    public class GifAdapter : IGifAdapter
    {
        private readonly IGifHttpClient httpClient;
        public GifAdapter(IGifHttpClient httpClient)
        {
            this.httpClient = httpClient;

        }
        public async Task<string> RetreiveRandomGif()
        {
            var respone = await httpClient.GetAsync("https://api.giphy.com/v1/gifs/random?api_key=0IlRPfjL5jNRTTkxfh8Tdoj0BMmfherx&tag=&rating=R");
            var gifs = await respone.Content.ReadAsStringAsync();

            var gifJson = JObject.Parse(gifs);

            var embededUri = gifJson["data"]["embed_url"].ToString();

            var code = Regex.Split(embededUri, "\\w+/");

            return code[2];
        }

    }
}