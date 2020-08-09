using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TaskManager_pet
{
    class TMLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new TMLogger();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private class TMLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, 
                TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText("TMlog.txt", formatter(state, exception));
                //Console.WriteLine(formatter(state, exception));
            }
        }

    }
}
