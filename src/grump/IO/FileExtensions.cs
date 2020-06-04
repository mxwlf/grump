using Grump.Abstractions;

namespace Grump.IO
{
    public static class FileExtensions
    {
        public static T As<T>(this File file) where T: class, IFileCapability
        {
            return file as T;
        }

        public static IReadableAsTextLines AsTextLines(this File file)
        {
            return file.ThrowIfNull().As<IReadableAsTextLines>();
        }

        public static IWriteable AsWriteable(this File file)
        {
            return file.ThrowIfNull().As<IWriteable>();
        }
    }
}