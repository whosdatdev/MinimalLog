namespace MinimalLog
{
    public interface ILogInfoProvider
    {
        string GetInfo(string text, Severity severity);
    }
}