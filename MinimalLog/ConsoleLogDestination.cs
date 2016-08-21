using System;
using System.Collections.Generic;

namespace MinimalLog
{
    public class ConsoleLogDestination : ILogDestination
    {
        private readonly Dictionary<Severity, Tuple<ConsoleColor, ConsoleColor>> _severityColors;

        public ConsoleLogDestination()
        {
            _severityColors = new Dictionary<Severity, Tuple<ConsoleColor, ConsoleColor>>
            {
                {Severity.Info, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkGray, ConsoleColor.White)},
                {Severity.Warning, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkYellow, ConsoleColor.Yellow)},
                {Severity.Error, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkRed, ConsoleColor.Red)}
            };
        }

        public ConsoleLogDestination(Dictionary<Severity, Tuple<ConsoleColor, ConsoleColor>> severityColors)
        {
            _severityColors = severityColors;
        }

        public void Write(string preText, string text, Severity severity)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = _severityColors[severity].Item1;
            Console.Write(preText);
            Console.ForegroundColor = _severityColors[severity].Item2;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        public void SetSeverityColor(Severity severity, ConsoleColor color1, ConsoleColor color2)
        {
            _severityColors[severity] = new Tuple<ConsoleColor, ConsoleColor>(color1, color2);
        }
    }
}