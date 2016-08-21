using System;

namespace MinimalLog
{
    public class LongTimeInfoProvider : ILogInfoProvider
    {
        public string GetInfo(string text, Severity severity)
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}