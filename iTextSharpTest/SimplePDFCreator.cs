using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharpTest.Utility;

namespace iTextSharpTest
{
    class SimplePDFCreator
    {
        HTMLTemplateConfig htmlTemplateConfig;
        private string htmlSouceFilePath;
        private UnicodeFontFactory unicodeFontFactory;
        private float defaultWidth = 0;
        private float defaultHeight = 0;

        public SimplePDFCreator()
        {
            unicodeFontFactory = new UnicodeFontFactory();
            htmlTemplateConfig.rectangle = PageSize.A4; //left0 right595 bottom0 top842
            htmlTemplateConfig.pageMarginLeft = 30;
            htmlTemplateConfig.pageMarginRight = 30;
            htmlTemplateConfig.pageMarginTop = 30;
            htmlTemplateConfig.pageMarginBottom = 30;
            defaultWidth = htmlTemplateConfig.rectangle.GetRight(0) - htmlTemplateConfig.rectangle.GetLeft(0);
            defaultHeight = htmlTemplateConfig.rectangle.GetTop(0) - htmlTemplateConfig.rectangle.GetBottom(0);
        }

        public void createPDF(string htmlPath)
        {
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("output/test.pdf", FileMode.Create));
            document.Open();
            String htmlContent = Utilities.ReadFileToString(htmlPath);

            byte[] data = Encoding.UTF8.GetBytes(htmlContent);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);
            XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, document, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
            document.Close();
        }

        public void createTwoColumnPDF(string htmlPath)
        {
            this.createTwoColumnPDF(htmlPath, "test");
        }

        public void createMultiColumnPdf(string htmlPath)
        {
            // step 1
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            // step 2
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("output/test.pdf", FileMode.Create));
            // step 3
            //document.Open();
            // step 4
            // CSS
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            cssResolver.AddCssFile("config/default.css", true);
            // HTML

            HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
            ITagProcessorFactory tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();

            MulityColumnTagProcessor mutilColumnTagProcessor = new MulityColumnTagProcessor();
            String[] tagList = { "div" };
            tagProcessorFactory.AddProcessor(mutilColumnTagProcessor, tagList);

            htmlContext.SetTagFactory(tagProcessorFactory);
            htmlContext.AutoBookmark(false);

            // Pipelines
            PdfWriterPipeline pdf = new PdfWriterPipeline(document, pdfWriter);
            HtmlPipeline html = new HtmlPipeline(htmlContext, pdf);
            CssResolverPipeline css = new CssResolverPipeline(cssResolver, html);

            // XML Worker
            XMLWorker xmlWorker = new XMLWorker(css, true);
            XMLParser xmlParser = new XMLParser(xmlWorker);

            String htmlContent = Utilities.ReadFileToString(htmlPath);
            byte[] data = Encoding.UTF8.GetBytes(htmlContent);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);

            xmlParser.Parse(msInput);
 
            // step 5
            document.Close();
        }

        public void createTwoColumnPDF(string htmlPath, string outputFileName)
        {
            // CSS
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            cssResolver.AddCssFile("config/default.css", true);
            // HTML
            CssAppliersImpl cssAppliersImpl = new CssAppliersImpl(unicodeFontFactory);
            HtmlPipelineContext htmlContext = new HtmlPipelineContext(cssAppliersImpl);
            ITagProcessorFactory tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();
            
            htmlContext.SetTagFactory(tagProcessorFactory);
            htmlContext.AutoBookmark(false);
            // Pipelines
            ElementList elements = new ElementList();
            ElementHandlerPipeline elementHandlerPipeline = new ElementHandlerPipeline(elements, null);
            HtmlPipeline htmlPipeline = new HtmlPipeline(htmlContext, elementHandlerPipeline);
            CssResolverPipeline cssResolverPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
            // XML Worker
            XMLWorker worker = new XMLWorker(cssResolverPipeline, true);
            //XMLWorkerEx worker = new XMLWorkerEx(cssResolverPipeline, true);
            XMLParser xmlParser = new XMLParser(worker);

            String htmlContent = Utilities.ReadFileToString(htmlPath);
            byte[] data = Encoding.UTF8.GetBytes(htmlContent);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);
            xmlParser.Parse(msInput);

            // step 1
            Document document = new Document(PageSize.LEGAL.Rotate());
            // step 2
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("output/" + outputFileName +".pdf", FileMode.Create));
            // step 3
            document.Open();
            // step 4

            Rectangle left = new Rectangle(36, 36, 486, 586);
            Rectangle right = new Rectangle(522, 36, 972, 586);
            ColumnText column = new ColumnText(writer.DirectContent);
            column.SetSimpleColumn(left);
            Boolean leftside = true;
            int status = ColumnText.NO_MORE_COLUMN;
            foreach (IElement element in elements)
            {
                if (ColumnText.isAllowedElement(element))
                {
                    column.AddElement(element);
                    status = column.Go();
                    Console.WriteLine("当前status:" + status);
                    while (ColumnText.HasMoreText(status))
                    {
                        if (leftside)
                        {
                            leftside = false;
                            column.SetSimpleColumn(right);
                        }
                        else
                        {
                            document.NewPage();
                            leftside = true;
                            column.SetSimpleColumn(left);
                        }
                        status = column.Go();
                        Console.WriteLine("HasMoreText当前status:" + status);
                    }
                }
            }
                
            // step 5
            document.Close();
        }



        /// <summary>
        /// 将Html文字 输出到PDF档里
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static byte[] ConvertHtmlTextToPDF(string htmlText)
        {
            if (string.IsNullOrEmpty(htmlText))
            {
                return null;
            }
            //避免当htmlText无任何html tag标签的纯文字时，转PDF时会挂掉，所以一律加上<p>标签
            htmlText = "<p>" + htmlText + "</p>";

            MemoryStream outputStream = new MemoryStream();//要把PDF写到哪个串流
            byte[] data = Encoding.UTF8.GetBytes(htmlText);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);
            Document document = new Document();//要写PDF的文件，建构子没填的话预设直式A4
            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);
            //指定文件预设开档时的缩放为100%
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, document.PageSize.Height, 1f);
            //开启Document文件 
            document.Open();
            //使用XMLWorkerHelper把Html parse到PDF档里
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
            //将pdfDest设定的资料写到PDF档
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            document.Close();
            msInput.Close();
            outputStream.Close();
            //回传PDF档案 
            return outputStream.ToArray();

        }


        public string HTMLSouceFilePath
        {
            get { return htmlSouceFilePath; }
            set { htmlSouceFilePath = value; }
        }

    }
}
