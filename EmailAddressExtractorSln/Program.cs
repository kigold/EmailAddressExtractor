using System;
using EmailAddressExtractorSln.Utils;

namespace EmailAddressExtractorSln
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("; ", EmailHelperExtension.GetEmailFromDoc("randam text kingsley@yahoo.com more random text kingsley@gmail.com")));
            Console.Read();
        }
    }
}
