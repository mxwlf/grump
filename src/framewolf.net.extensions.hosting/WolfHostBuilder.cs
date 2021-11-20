using Microsoft.Extensions.Hosting;
using mxwlf.net.Grump.Abstractions;

namespace Framewolf.Extensions.Hosting
{
    public class WolfHostBuilder: IWolfHostBuilder
    {
        private readonly IHostBuilder _genericHostBuilder;
        
        public WolfHostBuilder(IHostBuilder genericHostBuilder)
        {
            _genericHostBuilder = genericHostBuilder;
        }

        public IHostBuilder GenericHostBuilder => _genericHostBuilder;
        
        public IWolfHost Build()
        {
            
        }
    }
}