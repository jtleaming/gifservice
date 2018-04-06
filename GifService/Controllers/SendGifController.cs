using Microsoft.AspNetCore.Mvc;

namespace GifService.Controllers
{
    [Route("api/[controller]")]
    public class SendGifControllers : Controller
    {
        private readonly IGifAdapter gifAdapter;
        public SendGifControllers(IGifAdapter gifAdapter)
        {
            this.gifAdapter = gifAdapter;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var results = gifAdapter.RetreiveRandomGif();
            return Ok(results);
        }
    }
}