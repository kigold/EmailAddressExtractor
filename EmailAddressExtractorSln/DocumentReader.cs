using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
