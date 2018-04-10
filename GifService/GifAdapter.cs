using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        public async Task<List<string>> RetreiveRandomGif()
        {
            var respone = await httpClient.GetAsync("https://api.giphy.com/v1/gifs/random?api_key=0IlRPfjL5jNRTTkxfh8Tdoj0BMmfherx&tag=&rating=R");
            var gifs = await respone.Content.ReadAsStringAsync();

            var gifJson = JObject.Parse(gifs);
            var mediaUri = gifJson["data"]["images"]["downsized_large"]["url"].ToString();
            var embeddedUrl = gifJson["data"]["embed_url"].ToString();

            Encoding encode = Encoding.ASCII;
            byte [] bytes = encode.GetBytes(mediaUri);
            var enocdedMediaUrl = Convert.ToBase64String(bytes);

            bytes = encode.GetBytes(embeddedUrl);
            var enocdedEmbedUrl = Convert.ToBase64String(bytes);

            return new List<string>() { enocdedMediaUrl, enocdedEmbedUrl };
        }

    }
}