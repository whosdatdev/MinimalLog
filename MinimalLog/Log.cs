using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalLog
{
    public static class Log
    {
        public static readonly List<Tuple<ILogDestination, Severity>> Destinations = new List<Tuple<ILogDestination, Severity>> { new Tuple<ILogDestination, Severity>(new ConsoleLogDestination(), Severity.Trace) };
        public static readonly List<ILogInfoProvider> InfoProviders = new List<ILogInfoProvider> { new CallerInfoProvider() };
        public static string InfoFormat = "[{0}] ";

        public static void Write(string text, Severity severity = Severity.Info, bool stackTrace = true)
        {
            var pretext = InfoProviders.Aggregate(string.Empty, (current, t) => current + string.Format(InfoFormat, t.GetInfo(text, severity)));
            foreach (var logDestination in Destinations.Where(logDestination => logDestination.Item2 <= severity))
                logDestination.Item1.Write(pretext, text, severity);
        }
    }
}