using System;
using System.IO;
using System.Collections;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using RtfConverter.Parser;
using RtfConverter.RtfInterpreter.Image;
using RtfConverter.RtfInterpreter;
using RtfConverter.RtfInterpreter.Support;
using RtfConverter.HtmlSetting;
using System.Drawing.Imaging;

namespace RtfConverter
{
    public class HtmlConvert
    {
        private static string imagesDirectory { get; set; }
        /// <summary>
        /// convert the source rtf to html files
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output"></param>
        public static void RtfConvertHtml(string source,string output)
        {
            FileInfo fi = new FileInfo(output);
            if (!Path.GetExtension(source).Equals(".rtf"))
            {
                return;
            }
            if (!Directory.Exists(fi.Directory.FullName))
            {
                Directory.CreateDirectory(fi.Directory.FullName);
            }

            //create images directory
            imagesDirectory = Path.Combine(fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.FullName));
            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            // parse rtf
            IRtfGroup rtfStructure = ParseRtf(source);

            // image handling
            string imageFileNamePattern = Path.GetFileNameWithoutExtension(fi.FullName) + "{0}{1}";
            ImageFormat imageFormat = ImageFormat.Jpeg;
            RtfVisualImageAdapter imageAdapter = new RtfVisualImageAdapter(
                imageFileNamePattern,
                imageFormat);

            // interpret rtf
            IRtfDocument rtfDocument = InterpretRtf(rtfStructure, imageAdapter);


            // convert to hmtl
            string html = ConvertHmtl(rtfDocument, imageAdapter);


            // save html
            string fileName = SaveHmtl(html,output);            

        }
        private static IRtfGroup ParseRtf(string _source)
        {
            IRtfGroup rtfStructure;
            //RtfParserListenerFileLogger parserLogger = null;
            try
            {

                // rtf parser
                // open readonly - in case of dominant locks...
                using (FileStream stream = File.Open(_source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // parse the rtf structure
                    RtfParserListenerStructureBuilder structureBuilder = new RtfParserListenerStructureBuilder();
                    RtfParser parser = new RtfParser(structureBuilder);
                    parser.IgnoreContentAfterRootGroup = true; // support WordPad documents
                    
                    parser.Parse(new RtfSource(stream));
                    rtfStructure = structureBuilder.StructureRoot;
                }
            }
            catch (Exception e)
            {                

                Console.WriteLine("error while parsing rtf: " + e.Message);
                return null;
            }

            return rtfStructure;
        } // ParseRtf


        private static IRtfDocument InterpretRtf(IRtfGroup rtfStructure, IRtfVisualImageAdapter imageAdapter)
        {
            IRtfDocument rtfDocument;
            try
            {
                RtfImageConverter imageConverter = null;
                
                RtfImageConvertSettings imageConvertSettings = new RtfImageConvertSettings(imageAdapter);

                imageConvertSettings.ImagesPath = imagesDirectory;

                imageConverter = new RtfImageConverter(imageConvertSettings);

                // rtf interpreter
                RtfInterpreterSettings interpreterSettings = new RtfInterpreterSettings();

                // interpret the rtf structure using the extractors
                rtfDocument = RtfInterpreterTool.BuildDoc(rtfStructure, interpreterSettings,null, imageConverter);

            }
            catch (Exception e)
            {                

                Console.WriteLine("error while interpreting rtf: " + e.Message);

                return null;
            }

            return rtfDocument;
        } // InterpretRtf

        private static string ConvertHmtl(IRtfDocument rtfDocument, IRtfVisualImageAdapter imageAdapter)
        {
            string html;

            try
            {
                RtfHtmlConvertSettings htmlConvertSettings = new RtfHtmlConvertSettings(imageAdapter);

                htmlConvertSettings.ImagesPath = imagesDirectory;
                htmlConvertSettings.ImageDirectory = imagesDirectory;
                if(null != imagesDirectory)
                { 
                    var di = new DirectoryInfo(imagesDirectory);
                    htmlConvertSettings.ImageDirectory = di.Name;
                }
                

                RtfHtmlConverter htmlConverter = new RtfHtmlConverter(rtfDocument, htmlConvertSettings);                
                html = htmlConverter.Convert();
            }
            catch (Exception e)
            {
                Console.WriteLine("error while converting to html: " + e.Message);
                return null;
            }

            return html;
        } // ConvertHmtl
        private static string SaveHmtl(string text,string ouput)
        {

            string fileName = ouput;
            Encoding encoding = Encoding.UTF8;
            try
            {
                using (TextWriter writer = new StreamWriter(fileName, false, encoding))
                {
                    writer.Write(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error while saving html: " + e.Message);
                return null;
            }

            return fileName;
        } 
    }


}
