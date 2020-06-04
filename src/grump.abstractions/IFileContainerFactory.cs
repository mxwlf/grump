namespace Grump.Abstractions
{
    public interface IFileContainerFactory
    {
        IFileContainer GetFileContainer(string containerUri);
    }
}