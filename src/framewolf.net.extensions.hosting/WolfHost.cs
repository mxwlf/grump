using Microsoft.Extensions.Hosting;

namespace Framewolf.Extensions.Hosting
{
    public class WolfHost
    {
        private readonly IHost _genericHost;

        public WolfHost(IHost genericHost)
        {
            _genericHost = genericHost;
        }
    }
}