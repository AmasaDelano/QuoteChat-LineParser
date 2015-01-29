using System.Collections.Generic;
using System.IO;

namespace QuoteChatLineParser
{
    public class FileReader
    {
        private readonly string _fileName;

        public FileReader(string fileName)
        {
            _fileName = fileName;
        }

        public string[] GetFileLines()
        {
            var fileStream = File.OpenText(_fileName);

            List<string> lines = new List<string>();
            string currentLine;

            while ((currentLine = fileStream.ReadLine()) != null)
            {
                lines.Add(currentLine);
            }

            return lines.ToArray();
        }
    }
}