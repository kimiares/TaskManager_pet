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

                string path = @"C:\Users\Tino\source\repos\TaskManager_pet\Logs.txt";
                //File.AppendAllText("TMlog.txt", formatter(state, exception));
                File.AppendAllText(path, formatter(state, exception));

                //C:\Users\Tino\source\repos\TaskManager_pet

                //Console.WriteLine(formatter(state, exception));
            }
        }

    }
}
