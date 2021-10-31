using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code7248.word_reader;

namespace EmailAddressExtractorSln
{
    public static class DocumentReader
    {
        public static string ReadTextFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch
            {
                return "";
            }
        }

        public static string ReadWordFile(string filePath)
        {
            try
            {
                TextExtractor extractor = new TextExtractor(filePath);
                string text = extractor.ExtractText();
                return text;
            }
            catch
            {
                return "";
            }
        }
    }
}
