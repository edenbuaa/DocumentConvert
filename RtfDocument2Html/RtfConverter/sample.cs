using System;
using System.IO;

namespace RtfDocument2Html
{
    class Test
    {
        static void Main(string[] args)
        {

            RtfConverter.HtmlConvert.RtfConvertHtml(Path.Combine(Environment.CurrentDirectory, "sample-doc.rtf"), Path.Combine(Environment.CurrentDirectory, "test"));           
            Console.WriteLine("-------END-----------");
            Console.ReadLine();
            
        }

       
    }
}
