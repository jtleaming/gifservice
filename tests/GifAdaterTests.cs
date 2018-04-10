using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GifService;
using GifService.Common;
using Moq;
using Xunit;

namespace tests
{
    public class tests
    {
        [Fact]
        public async void RetreiveRandomGif_ReturnsBase64String_WhenReceivesGifResponseJson()
        {
            //Given
            var mockHttpClient = new Mock<IGifHttpClient>();
            var gifAdapter = new GifAdapter(mockHttpClient.Object);

            mockHttpClient.Setup(g => g.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage() { Content = new StringContent(File.ReadAllText("Fixtures/gifResponse.json")) }));
            //When
            string gifUri = await gifAdapter.RetreiveRandomGif();

            //Then
            Assert.Equal("aHR0cHM6Ly9naXBoeS5jb20vZW1iZWQvMjZGUEZCUEVON1BEUlpqM08=", gifUri);
        }
    }
}