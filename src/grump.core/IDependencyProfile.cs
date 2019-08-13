using Microsoft.Extensions.DependencyInjection;

namespace Grump.Core
{
    public interface IDependencyProfile
    {
        void BuildDependencies(IServiceCollection services);
    }
}
