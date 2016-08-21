using System.Diagnostics;

namespace MinimalLog
{
    internal class CallerInfoProvider : ILogInfoProvider
    {
        public string GetInfo(string text, Severity severity)
        {
            var trace = new StackTrace().GetFrame(4).GetMethod();
            return $"{trace.DeclaringType?.FullName ?? "?"}.{trace.Name}";
        }
    }
}