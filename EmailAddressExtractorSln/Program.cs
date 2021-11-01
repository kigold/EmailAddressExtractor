using System;
using System.Collections.Generic;
using System.IO;
using EmailAddressExtractorSln.Utils;

namespace EmailAddressExtractorSln
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var emailsResult = new HashSet<string>();
            string folderPath = string.Empty;

            var files = Directory.GetFiles(folderPath);

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file);
                var text = string.Empty;

                if (ext.ToLower().Contains("doc"))
                {
                    text = DocumentReader.ReadWordFile(file);
                    var emails = EmailHelperExtension.GetEmailFromDoc(text);
                    emailsResult.UnionWith(emails);
                }
                else if (ext.ToLower().Contains("txt"))
                {
                    text = DocumentReader.ReadTextFile(file);
                    var emails = EmailHelperExtension.GetEmailFromDoc(text);
                    emailsResult.UnionWith(emails);
                }
            }

            var outputFile = Path.Combine(folderPath, "output.txt");
            using (StreamWriter file = new StreamWriter(outputFile))
            {
                foreach (string email in emailsResult)
                {
                    file.WriteLine($"{email};");
                }
                file.WriteLine($"There were a total of {emailsResult.Count} email addresses found;");
            }
            Console.Read();
        }
    }
}
