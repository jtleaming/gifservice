using System.Threading.Tasks;

namespace GifService
{
    public interface IGifAdapter
    {
         Task<string> RetreiveRandomGif();
         
    }
}