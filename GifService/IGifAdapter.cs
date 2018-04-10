using System.Collections.Generic;
using System.Threading.Tasks;

namespace GifService
{
    public interface IGifAdapter
    {
         Task<List<string>> RetreiveRandomGif();
         
    }
}