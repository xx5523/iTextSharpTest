using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharpTest.Utility;

namespace iTextSharpTest
{
    class SimplePDFCreator
    {

        public static void createPDF(string htmlPath)
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
            Document doc = new Document();//要写PDF的文件，建构子没填的话预设直式A4
            PdfWriter writer = PdfWriter.GetInstance(doc, outputStream);
            //指定文件预设开档时的缩放为100%
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);
            //开启Document文件 
            doc.Open();
            //使用XMLWorkerHelper把Html parse到PDF档里
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
            //将pdfDest设定的资料写到PDF档
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            doc.Close();
            msInput.Close();
            outputStream.Close();
            //回传PDF档案 
            return outputStream.ToArray();

        }
    }
}
