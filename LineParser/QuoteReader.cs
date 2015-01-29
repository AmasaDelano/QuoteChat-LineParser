using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteChatLineParser
{
    public class QuoteReader
    {
        private readonly FileReader _fileReader;

        public QuoteReader(FileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string[] GetAllQuotes()
        {
            var fileLines = _fileReader.GetFileLines();

            var quotes = SplitIntoQuotes(fileLines);

            return quotes.Select(e => e.ToString()).ToArray();
        }

        private static IEnumerable<Quote> SplitIntoQuotes(IList<string> fileLines)
        {
            var lineGroups = GatherLinesIntoGroups(fileLines);

            var quotes = new List<Quote>();

            foreach (var lineGroup in lineGroups)
            {
                var quote = new Quote(lineGroup);
                quotes.Add(quote);
            }

            return quotes;
        }

        private static IEnumerable<List<string>> GatherLinesIntoGroups(IList<string> fileLines)
        {
            var lineGroups = new List<List<string>>();

            int lineGroupBorder = 0;

            for (int lineIndex = 0; lineIndex < fileLines.Count(); lineIndex += 1)
            {
                if (string.IsNullOrEmpty(fileLines[lineIndex]))
                {
                    var fileGroup = fileLines
                        .Skip(lineGroupBorder)
                        .Take(lineIndex - lineGroupBorder + 1)
                        .ToList();
                    
                    lineGroups.Add(fileGroup);

                    lineGroupBorder = lineIndex + 1;
                }
            }

            lineGroups = lineGroups
                .Where(e => !e.All(string.IsNullOrEmpty))
                .ToList();

            return lineGroups;
        }

        private class Quote
        {
            public Quote(IReadOnlyCollection<string> lineGroup)
            {
                if (lineGroup.Count < 3)
                {
                    throw new ArgumentException("Line group must have at least 3 lines.");
                }

                // Set line times
                string timesText = lineGroup.Skip(1).First();
                var times = timesText.Split(' ');
                LineStart = new LineTimeStamp(times[0]);
                LineEnd = new LineTimeStamp(times[2]);

                // Set the line itself
                Line = string.Join(" ", lineGroup.Skip(2).Select(e => e.Trim()));
            }

            private LineTimeStamp LineStart { get; set; }
            private LineTimeStamp LineEnd { get; set; }
            private string Line { get; set; }

            public override string ToString()
            {
                return string.Join(
                    Environment.NewLine,
                    LineStart.ToString(),
                    LineEnd.ToString(),
                    Line
                    );
            }

            private class LineTimeStamp
            {
                private TimeSpan _timeSpan;
                private const string TimeSpanFormat = @"hh\:mm\:ss\,fff";

                public LineTimeStamp(string timeStamp)
                {
                    _timeSpan = TimeSpan.ParseExact(timeStamp, TimeSpanFormat, null);
                }

                public override string ToString()
                {
                    return _timeSpan.ToString();
                }
            }
        }
    }
}