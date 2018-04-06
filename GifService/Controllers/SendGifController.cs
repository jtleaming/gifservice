using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GifService.Controllers
{
    [Route("api/[controller]")]
    public class SendGifController : Controller
    {
        private readonly IGifAdapter gifAdapter;
        public SendGifController(IGifAdapter gifAdapter)
        {
            this.gifAdapter = gifAdapter;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await gifAdapter.RetreiveRandomGif();
            return Ok(results);
        }
    }
}