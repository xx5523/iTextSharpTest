using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.tool.xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharpTest.Utility;

namespace iTextSharpTest
{
    public partial class MainForm : Form
    {

        //FileStream dest;
        //Document document = new Document();
        BaseFont bfTimes;
        public const string FONT = "c:/windows/fonts/msyh.ttf";
        BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        int totalfonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");

        public MainForm()
        {
            InitializeComponent();
            //dest = new FileStream("output/test.pdf", FileMode.Create);
            bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //baseFont = BaseFont.CreateFont("");
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            //PdfWriter pdfWriter = new PdfWriter(dest);
            //PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            //Document document = new Document(pdfDocument);
            //document.Add(new Paragraph("Hello World!"));
            //document.Close();
            createPDF("input/1.html");
            //SimplePDFCreator.createPDF("input/2.html");
            string appBasePath = AppDomain.CurrentDomain.BaseDirectory;
            System.Console.WriteLine(appBasePath);
            webBrowserForPDF.Navigate(appBasePath + "hehe.html");
        }

        private void createPDF(string htmlPath)
        {
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("output/test.pdf", FileMode.Create));
            document.Open();
            String css = "html{font-family:仿宋} #aaa {border-top:1px dashed #cccccc;height: 1px;overflow:hidden;}";
            //iTextSharp.text.Font font = FontFactory.GetFont("宋体", 7);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf);
            //document.Add(new Paragraph("仿宋仿宋仿宋仿宋仿宋仿宋仿宋仿宋Hello WWWWWWWWWWWorld!", font));
            String html = Utilities.ReadFileToString(htmlPath);
            //Console.Write(html);
            //ElementList list = XMLWorkerHelper.ParseToElementList(html, css);
            //Paragraph paragraph;
            //foreach (IElement element in list)
            //{
            //    paragraph = (Paragraph) element;
            //    document.Add(element);
            //}
            
            TextReader reader = new StringReader(html);

            byte[] data = Encoding.UTF8.GetBytes(html);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);
            XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, document, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
            document.Close();
        }

        private void btnChooseHtml_Click(object sender, EventArgs e)
        {
            openHtmlDialog.Filter = "文本文件（*.txt）|*.txt|html网页文件（*.html）|*.html";
            openHtmlDialog.ShowDialog();
            tBhtmlPath.Text = openHtmlDialog.FileName;
        }
    }
}
