namespace framewolf.net.Extensions.Hosting.Abstractions
{
    public interface IWolfHost
    {
        T GetService<T>();
    }
}