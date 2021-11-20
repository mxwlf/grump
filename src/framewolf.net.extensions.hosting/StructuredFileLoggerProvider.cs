using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace grump.hosting
{
    public class StructuredFileLoggerProvider : ILoggerProvider
    {
        private readonly StructuredFileLoggerOptions _options;
        private static StructuredFileLogger _logger;
 
        public StructuredFileLoggerProvider(IOptions<StructuredFileLoggerOptions> options)
        {
            this._options = options.Value;
            
            if (!Directory.Exists(this._options.FolderPath))
            {
                Directory.CreateDirectory(this._options.FolderPath);
            }
        }
 
        public ILogger CreateLogger(string categoryName)
        {
            return _logger ??= new StructuredFileLogger(_options);
        }
 
        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}