using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GifService;
using GifService.Common;
using Moq;
using Xunit;

namespace tests
{
    public class tests
    {
        [Fact]
        public async void GifAdaterTests()
        {
            //Given
            var mockHttpClient = new Mock<IGifHttpClient>();
            var gifAdapter = new GifAdapter(mockHttpClient.Object);

            mockHttpClient.Setup(g => g.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage() { Content = new StringContent(File.ReadAllText("Fixtures/gifResponse.json")) }));
            //When
            string gifUri = await gifAdapter.RetreiveRandomGif();
            //Then
            Assert.Equal("https://giphy.com/embed/26FPFBPEN7PDRZj3O", gifUri);
        }
    }
}