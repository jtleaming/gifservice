using GifService;
using Xunit;

namespace tests
{
    public class tests
    {
        [Fact]
        public void GifAdaterTests()
        {
        //Given
        var gifAdapter = new GifAdapter();
        //When
        string gifUri = gifAdapter.RetreiveRandomGif();
        //Then
        Assert.Equal(gifUri, "http://gif");
        }
    }
}