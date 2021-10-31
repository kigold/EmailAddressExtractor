using System;
using System.Collections.Generic;
using System.IO;
using EmailAddressExtractorSln.Utils;

namespace EmailAddressExtractorSln
{
    public class Program
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
            Console.WriteLine(string.Join("; ", emailsResult));
            Console.Read();
        }
    }
}
