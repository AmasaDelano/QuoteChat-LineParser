using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteChatLineParser
{
    public sealed class Quote
    {
        private readonly LineTimeStamp _lineStart;
        private readonly LineTimeStamp _lineEnd;
        private readonly string _line;

        public Quote(IReadOnlyCollection<string> lineGroup)
        {
            if (lineGroup.Count < 3)
            {
                throw new ArgumentException("Line group must have at least 3 lines.");
            }

            // Set line times
            string timesText = lineGroup.Skip(1).First();
            var times = timesText.Split(' ');
            _lineStart = new LineTimeStamp(times[0]);
            _lineEnd = new LineTimeStamp(times[2]);

            // Set the line itself
            _line = string.Join(" ", lineGroup.Skip(2).Select(e => e.Trim()));
            _line = CleanLine(_line);
        }

        private static string[] ThingsToRemove = new[]
            {
                @"<i>",
                @"</i>"
            };

        private static string CleanLine(string line)
        {
            string cleanedLine = line;

            foreach (string thingToRemove in ThingsToRemove)
            {
                cleanedLine = cleanedLine.Replace(thingToRemove, string.Empty);
            }

            return cleanedLine;
        }

        public string Line
        {
            get { return _line; }
        }

        public TimeSpan TimeStart
        {
            get { return (TimeSpan) _lineStart; }
        }

        public TimeSpan TimeEnd
        {
            get { return (TimeSpan) _lineEnd; }
        }

        public QuoteData GetData()
        {
            var data = new QuoteData
            {
                TimeStart = TimeStart,
                TimeEnd = TimeEnd,
                Line = Line
            };

            return data;
        }

        private class LineTimeStamp
        {
            private TimeSpan _timeSpan;
            private const string TimeSpanFormat = @"hh\:mm\:ss\,fff";

            public LineTimeStamp(string timeStamp)
            {
                _timeSpan = TimeSpan.ParseExact(timeStamp, TimeSpanFormat, null);
            }

            public static explicit operator TimeSpan(LineTimeStamp lineTimeStamp)
            {
                return lineTimeStamp._timeSpan;
            }

            public override string ToString()
            {
                return _timeSpan.ToString();
            }
        }

        public struct QuoteData
        {
            public TimeSpan TimeStart { get; set; }

            public TimeSpan TimeEnd { get; set; }

            public string Line { get; set; }
        }
    }
}