using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace grump.hosting
{
    public class StructuredFileLogger : ILogger, IDisposable, IAsyncDisposable
    {
        private static readonly EventId FlushingEvent = new(15, "StructuredFileLogger shutting down.");

        private static readonly ConcurrentBag<StructuredLogEntry> Entries = new();
        private readonly StructuredFileLoggerOptions _options;
        
        private static bool IsBeingDisposed
        {
            get
            {
                lock (DisposalLock)
                {
                    return _isBeingDisposed;
                }
            }
            set
            {
                lock (DisposalLock)
                {
                    _isBeingDisposed = value;
                }
                
            }
        }

        private static bool _isBeingDisposed;
        private static readonly object DisposalLock = new object();

        public StructuredFileLogger(StructuredFileLoggerOptions options)
        {
            _options = options;
            
            // if (options?.DopPlatformInformation?.ApplicationStopped != null)
            // {
            //     options.DopPlatformInformation.ApplicationStopped.Register(
            //         async () =>
            //             await DisposeAsync().ConfigureAwait(false)
            //     );
            // }
        }

        private async Task FlushLogIntoFileAsync()
        {
            Log(LogLevel.Information, FlushingEvent, "StructuredFileLogger", null, (s, exception) => "Shutting down signaled, flushing the logs into file.");
            
            var fullFilePath = _options.FolderPath + "/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".json";
            var sessionInformation = new SessionInformation { Entries = Entries.OrderBy(x => x.DateTime).ToArray()};
            var operationTimes = new Dictionary<string, List<long>>();
            foreach (var entry in Entries)
            {
                if (default == entry.ElapsedTimeInMilliseconds)
                {
                    continue;
                }

                var operationName = entry.OperationName;
                    
                if (!operationTimes.ContainsKey(operationName))
                {
                    operationTimes.Add(operationName, new List<long>());
                }
                    
                operationTimes[operationName].Add(entry.ElapsedTimeInMilliseconds);
            }
            
            var operationAverages = new Dictionary<string, long>();
            foreach (var operation in operationTimes.Keys)
            {
                operationAverages.Add(operation, operationTimes[operation].Sum(x => x) / operationTimes[operation].Count);
            }

            //var averageList = new List<OperationAverage>();
            
            // foreach (var op in operationAverages)
            // {
            //     averageList.Add( new OperationAverage { OperationName = op.Key, ElapsedTimeInMilliseconds = op.Value });
            // }
            //
            // sessionInformation.Averages = averageList.ToArray();

            var fileContent = JsonConvert.SerializeObject(sessionInformation, Newtonsoft.Json.Formatting.Indented);
            
            await File.WriteAllTextAsync(fullFilePath, fileContent, Encoding.UTF8);
        }
 
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
 
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }
 
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var formattedValues = state as IReadOnlyList<KeyValuePair<string, object>>;
            
            if (formattedValues != null)
            {
                var entry = StructuredLogEntry.Build();
                entry.DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                entry.LogLevel = logLevel.ToString();
                entry.Data = new Dictionary<string, object>(formattedValues);

                if (entry.Data.ContainsKey("OperationName"))
                {
                    entry.OperationName = entry.Data["OperationName"].ToString();
                }
                if (entry.Data.ContainsKey("ElapsedTimeInMilliseconds"))
                {
                    if (double.TryParse(entry.Data["ElapsedTimeInMilliseconds"].ToString(), out double doubleValue))
                    {
                        var milliseconds = (long) Math.Truncate(doubleValue);
                        entry.ElapsedTimeInMilliseconds = milliseconds;
                    }
                }

                Entries.Add(entry);
            }

        }

        public void Dispose()
        {
            DisposeAsync().AsTask().Wait();
        }

        public async ValueTask DisposeAsync()
        {
            if (!IsBeingDisposed)
            {
                IsBeingDisposed = true;
                await FlushLogIntoFileAsync().ConfigureAwait(false);
            }
            
        }
    }
    
    
}