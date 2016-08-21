using System.Collections.Generic;
using System.Linq;

namespace MinimalLog
{
    public static class Log
    {
        public static readonly List<ILogDestination> Destinations = new List<ILogDestination> {new ConsoleLogDestination()};
        public static readonly List<ILogInfoProvider> InfoProviders = new List<ILogInfoProvider> {new CallerInfoProvider()};
        public static string InfoFormat = "[{0}] ";

        public static void Write(string text, Severity severity = Severity.Info, bool stackTrace = true)
        {
            var pretext = InfoProviders.Aggregate(string.Empty, (current, t) => current + string.Format(InfoFormat, t.GetInfo(text, severity)));
            foreach (var logDestination in Destinations)
                logDestination.Write(pretext, text, severity);
        }
    }
}