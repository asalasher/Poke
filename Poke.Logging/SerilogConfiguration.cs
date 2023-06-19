using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;

namespace Poke.Logging
{
    public class SerilogConfiguration
    {
        private static readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "SerilogPoke.log");

        public static SerilogLoggerProvider ConfigureLog()
        {
            return new SerilogLoggerProvider(new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(_logFilePath)
                .CreateLogger());
        }
    }
}
