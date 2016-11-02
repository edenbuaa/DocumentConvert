namespace DocMgr
{
    /// <summary>
    /// Test for PDF function with wkhtmltopdf SDK
    /// </summary>
    public class DocumentManager
    {
        public Task<bool> HTMLtoPDFAsync(PdfDocument doc)
        {
            return Task.Run(() => HtmlToPdf(doc));
        }

        private bool HtmlToPdf(PdfDocument document)
        {
           //running task

        }

        //merge pdfs by ghostscript
        private bool AttachChartDocuments()
        {
            var appBase = AppDomain.CurrentDomain.BaseDirectory; 
            var tempPath = appBase + "tmp";
            var gsdllPath = Path.Combine(appBase + "bin", OSHelper.WapperStartKey4gs + "dll");
            try
            {
                //prepare temp files
                if (File.Exists(gsdllPath))
                {
                    var strongDllName = "gsdll64.dll";
                    var dllPath = Path.Combine(appBase + "bin", strongDllName);
                    if(!File.Exists(dllPath))
                    { 
                        var directory = Path.GetDirectoryName(gsdllPath);
                        var destinationPath = Path.Combine(directory, strongDllName);
                        File.Move(gsdllPath, destinationPath);
                    }
                }

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                //get a copy of html pdf
                var htmlPdfCopy = Path.Combine(tempPath, "copy.pdf");

                File.Copy(PDFFileFullName, htmlPdfCopy);

                DataTable dt = Documents.Tables[0];
                StringBuilder docPdfs = new StringBuilder();
                int loc = 0;

                //generator pdf from blob byte
                foreach (DataRow dr in dt.Rows)
                {
                    var fi = new FileInfo((string)dr["DocFileName"]);
                    var isPdf = fi.Extension.Equals(".pdf");
                    var isWord = fi.Extension.Equals(".docx") || fi.Extension.Equals(".doc");
                    if (!isPdf && !isWord)
                    {
                        continue;
                    }                   

                    string middleFileName = Path.Combine(tempPath, string.Format("doc{0}{1} ", loc,fi.Extension));   

                    string tempFileName = Path.Combine(tempPath, string.Format("doc{0}.pdf ", loc++));

                    using (System.IO.FileStream fs = new System.IO.FileStream(middleFileName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                    {

                        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                        {
                            try
                            {
                                bw.Write(FileCompress.DecompressToBytes((byte[])dr["DocBlob"], dr["DocFileName"].ToString(), "BT", System.DateTime.Now));

                                bw.Close();
                            }
                            catch (Exception ex)
                            {
                                //do nothing, and ignore this exception.
                                continue;
                            }

                        }

                        //convert word to pdf ,try out best and it may convert fail
                        if (File.Exists(middleFileName) && isWord)
                        {
                            ConvertChartWord2Pdf(middleFileName, tempFileName);                            
                        }

                        //collect middle files
                        if (File.Exists(tempFileName))
                        {
                            docPdfs.Append(tempFileName);
                        }
                    }

                    
                }

                //merge them together 
                if (1 < docPdfs.Length)
                {
                    string controlParam = string.Format(" -dNOPAUSE -sDEVICE=pdfwrite -sOUTPUTFILE={0} -dBATCH  ", PDFFileFullName);
                    string gsParams = string.Format("{0} {1} {2}", controlParam, htmlPdfCopy, docPdfs.ToString());

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = _gsProgram,
                        Arguments = gsParams,
                        UseShellExecute = false
                    };

                    using (var p = new Process())
                    {
                        p.StartInfo = startInfo;

                        p.EnableRaisingEvents = true;

                        p.Exited += new EventHandler((s,e) => {

                           //

                        });

                        p.Start();
                        
                        p.WaitForExit();

                        // read the exit code
                        var returnCode = p.ExitCode;
                        result = (returnCode == 0) || (returnCode == 2);
                    }
                }
                

            }
            catch (Exception ex)
            {
                //TODO
                result = false;
            }
            finally 
            {
                //clean up
                if (Directory.Exists(tempPath))
                {
                    var dir = new DirectoryInfo(tempPath);
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                    dir.Delete(true);
                }
            }
            return result;           
        }

        /// <summary>
        /// Load wkhtmltopdf command line program
        /// note: 
        /// We can copy the latest wkhtmltopdf.exe 
        /// to the Bin folder
        /// ---------------------------
        /// modified by Peter 10/26/16
        /// we also want to load Ghostscript lib , merge them together!
        /// </summary>
        private void LoadWkHtmltoPdfLib(string wrapperStartKey = OSHelper.WapperStartKey)
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var binPath = appPath +"bin";
            var executingAssembly = Assembly.LoadFrom(appPath + OSHelper.PdfEngineWrapper);

            var manifestResourceNames = executingAssembly.GetManifestResourceNames();

            foreach (var name in manifestResourceNames)
            {
                if (!name.StartsWith(wrapperStartKey)) continue;
                var path = Path.Combine(binPath, Path.GetFileNameWithoutExtension(name));

                if (OSHelper.WapperStartKey4gs == wrapperStartKey && name.Contains(".exe"))
                {
                    _gsProgram = path;
                }
                else if(OSHelper.WapperStartKey == wrapperStartKey)
                { 
                    _pdfProgram = path;
                }

                lock (GlobalObj)
                {
                    if (File.Exists(path))
                    {
                        SetFullControlRights(path, OSHelper.MsmqUser);

                        if (File.GetLastWriteTime(path) > File.GetLastWriteTime(executingAssembly.Location))
                            continue;
                    }

                    if (!Directory.Exists(binPath))
                        Directory.CreateDirectory(binPath);
                    var stream = executingAssembly.GetManifestResourceStream(name);

                    if (stream != null)
                        using (var resource1 = new GZipStream(stream, CompressionMode.Decompress, false))
                        {
                            using (var resource0 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                var local9 = new byte[65536];
                                int local10;
                                while ((local10 = resource1.Read(local9, 0, local9.Length)) > 0)
                                    resource0.Write(local9, 0, local10);
                            }
                        }

                    SetFullControlRights(path, OSHelper.MsmqUser);
                }
            }
        }

        private static void SetFullControlRights(string fileName, string account)
        {
            if (!FileCompress.IsFileUserSecurity(fileName, account, FileSystemRights.FullControl))
            {
                // Add the FullControl rights to the file.
                FileCompress.AddFileUserSecurity(fileName, account, FileSystemRights.FullControl, AccessControlType.Allow);
            }
        }

        /// <summary>
        /// Print chart word file(.doc/.docx) to PDF follow the steps:
        /// .docx => .html -> .pdf
        /// ,and Powered by OpenXmlPowerTools
        /// >>PM Install-Package OpenXmlPowerTools 
        /// https://github.com/OfficeDev/Open-Xml-PowerTools
        /// </summary>
        /// <param name="output">
        /// path of the genered pdf, given by full name,suffix is .html
        /// </param>
        /// <param name="source">
        /// path of the word file , given by full name
        /// </param>
        /// <returns></returns>
        private bool ConvertChartWord2Pdf(string source,string output)
        {
            var result = true;
            try
            {
                //step 1, .docx => .html
                var tempHtmlPathInfo = new FileInfo(source);

                //temp html files ,xx/xx/abc.html
                var tempHtmlPath = Path.Combine(tempHtmlPathInfo.DirectoryName, "html", Path.GetFileNameWithoutExtension(source) + ".html");

                ConvertDocToHtml(source, tempHtmlPath);

                //OK,Done. step 2, .html => .pdf

                if (File.Exists(tempHtmlPath))
                {
                    ConvertHtmlToPdf(tempHtmlPath, output);
                }
            }
            catch (Exception ex)
            {
                //TODO
                result = false;
            }
            return result;
        }
        
        //convert word to html by openxmlpowertool
        private void ConvertDocToHtml(string source, string output)
        {
            var fi = new FileInfo(source);
            byte[] byteArray = File.ReadAllBytes(fi.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wDoc = WordprocessingDocument.Open(memoryStream, true))
                {
                    var destFileName = new FileInfo(output);
                    var outputDirectory = destFileName.DirectoryName;
                    
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }

                    var imageDirectoryName = destFileName.FullName.Substring(0, destFileName.FullName.Length - 5) + "_files";
                    int imageCounter = 0;

                    var pageTitle = fi.FullName;
                    var part = wDoc.CoreFilePropertiesPart;
                    if (part != null)
                    {
                        pageTitle = (string)part.GetXDocument().Descendants(DC.title).FirstOrDefault() ?? fi.FullName;
                    }

                    // TODO: Determine max-width from size of content area.
                    HtmlConverterSettings settings = new HtmlConverterSettings()
                    {
                        AdditionalCss = "body { margin: 1cm auto; max-width: 20cm; padding: 0; }",
                        PageTitle = pageTitle,
                        FabricateCssClasses = true,
                        CssClassPrefix = "pt-",
                        RestrictToSupportedLanguages = false,
                        RestrictToSupportedNumberingFormats = false,
                        ImageHandler = imageInfo =>
                        {
                            DirectoryInfo localDirInfo = new DirectoryInfo(imageDirectoryName);
                            if (!localDirInfo.Exists)
                                localDirInfo.Create();
                            ++imageCounter;
                            string extension = imageInfo.ContentType.Split('/')[1].ToLower();
                            ImageFormat imageFormat = null;
                            if (extension == "png")
                                imageFormat = ImageFormat.Png;
                            else if (extension == "gif")
                                imageFormat = ImageFormat.Gif;
                            else if (extension == "bmp")
                                imageFormat = ImageFormat.Bmp;
                            else if (extension == "jpeg")
                                imageFormat = ImageFormat.Jpeg;
                            else if (extension == "tiff")
                            {
                                // Convert tiff to gif.
                                extension = "gif";
                                imageFormat = ImageFormat.Gif;
                            }
                            else if (extension == "x-wmf")
                            {
                                extension = "wmf";
                                imageFormat = ImageFormat.Wmf;
                            }

                            // If the image format isn't one that we expect, ignore it,
                            // and don't return markup for the link.
                            if (imageFormat == null)
                                return null;

                            string imageFileName = imageDirectoryName + "/image" +
                                imageCounter.ToString() + "." + extension;
                            try
                            {
                                imageInfo.Bitmap.Save(imageFileName, imageFormat);
                            }
                            catch (System.Runtime.InteropServices.ExternalException)
                            {
                                return null;
                            }
                            string imageSource = localDirInfo.Name + "/image" +
                                imageCounter.ToString() + "." + extension;

                            XElement img = new XElement(Xhtml.img,
                                new XAttribute(NoNamespace.src, imageSource),
                                imageInfo.ImgStyleAttribute,
                                imageInfo.AltText != null ?
                                    new XAttribute(NoNamespace.alt, imageInfo.AltText) : null);
                            return img;
                        }
                    };
                    XElement htmlElement = HtmlConverter.ConvertToHtml(wDoc, settings);

                    // Produce HTML document with <!DOCTYPE html > declaration to tell the browser
                    // we are using HTML5.
                    var html = new XDocument(
                        new XDocumentType("html", null, null, null),
                        htmlElement);

                    // Note: the xhtml returned by ConvertToHtmlTransform contains objects of type
                    // XEntity.  PtOpenXmlUtil.cs define the XEntity class.  See
                    // http://blogs.msdn.com/ericwhite/archive/2010/01/21/writing-entity-references-using-linq-to-xml.aspx
                    // for detailed explanation.
                    //
                    // If you further transform the XML tree returned by ConvertToHtmlTransform, you
                    // must do it correctly, or entities will not be serialized properly.

                    var htmlString = html.ToString(SaveOptions.DisableFormatting);
                    File.WriteAllText(destFileName.FullName, htmlString, Encoding.UTF8);
                }

            }
        }

        //convert html to pdf by wkhtml
        private void ConvertHtmlToPdf(string source, string output)
        {
            var wkParams = string.Format(" {0} {1}",source,output);

            var startInfo = new ProcessStartInfo
            {
                FileName = _pdfProgram,
                Arguments = wkParams,
                UseShellExecute = false
            };

            using (var p = new Process())
            {
                p.StartInfo = startInfo;
               
                p.Start();
                
                p.WaitForExit();               
            }

        }
    }
}
