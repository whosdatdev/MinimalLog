namespace MinimalLog
{
    internal class SeverityInfoProvider : ILogInfoProvider
    {
        public string GetInfo(string text, Severity severity)
        {
            return severity.ToString();
        }
    }
}