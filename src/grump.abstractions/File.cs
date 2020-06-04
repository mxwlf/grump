namespace Grump.Abstractions
{
    public abstract class File : IFileCapability
    {
        public readonly string FullPath;
        private bool? _confirmedExistence;

        internal File(string fullPath, bool exists = false)
        {
            FullPath = fullPath;
            _confirmedExistence = exists;
        }
    }
}