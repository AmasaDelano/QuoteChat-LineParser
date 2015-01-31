using System.Collections.Generic;
using System.Linq;

namespace QuoteChatLineParser
{
    public sealed class QuoteReader
    {
        private readonly FileReader _fileReader;

        public QuoteReader(FileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public Quote[] GetAllQuotes()
        {
            var fileLines = _fileReader.GetFileLines();

            var quotes = SplitIntoQuotes(fileLines);

            return quotes.ToArray();
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
    }
}