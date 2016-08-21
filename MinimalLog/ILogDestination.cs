namespace MinimalLog
{
    public interface ILogDestination
    {
        void Write(string preText, string text, Severity severity);
    }
}