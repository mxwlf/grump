using Microsoft.Extensions.DependencyInjection;

namespace Grump.Abstractions
{
    public interface IDependencyProfile
    {
        void BuildDependencies(IServiceCollection services);
    }
}
