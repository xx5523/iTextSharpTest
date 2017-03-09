using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.pipeline.html;

namespace iTextSharpTest.Utility
{
    class MulityColumnTagProcessor : Div
    {

        float currentHeight = 0;
        int status = 0;
        int currentPagesNumber = 1;
        float columnHeigthCount = 0;

        public override IList<IElement> Content(IWorkerContext ctx, Tag tag, String content)
        {
            string mulityColumnAttr = "mulity-column";
            Console.WriteLine("content:" + content);
            var retval = base.Content(ctx, tag, content);
            if (tag.Attributes.ContainsKey(mulityColumnAttr) && tag.Attributes[mulityColumnAttr] == "true")
            {
                foreach (IElement element in retval)
                {
                    foreach (var chunk in element.Chunks)
                    {
                        Console.WriteLine("content:" + content);
                    }
                    
                }
            }
            return retval;
        }

        public override IList<iTextSharp.text.IElement> End(iTextSharp.tool.xml.IWorkerContext ctx, iTextSharp.tool.xml.Tag tag, IList<iTextSharp.text.IElement> currentContent)
        {
            string mulityColumnAttr = "mulity-column";
            List<IElement> list = new List<IElement>(1);
            MapContext mapContext = new MapContext();
            List<IElement> l = new List<IElement>(1);
            try
            {
                mapContext = (MapContext)ctx.Get("iTextSharp.tool.xml.pipeline.end.PdfWriterPipeline");
            }
            catch (NoCustomContextException ex)
            {
                Console.WriteLine("ex:" + ex);
            }

            Document document = (Document)mapContext["DOCUMENT"];
            PdfWriter pdfWriter = (PdfWriter) mapContext["WRITER"];
            float middle = (document.Left + document.Right) / 2;
            float[,] columns = {
                { document.Left, document.Bottom, middle - 15, document.Top } ,
                { middle + 15, document.Bottom, document.Right, document.Top }
            };
            
            document.Open();

            PdfContentByte pdfContentByte = pdfWriter.DirectContent;
           
            ColumnText columnText = new ColumnText(pdfContentByte);
            Console.WriteLine("创建columnText");
            int linesWritten = 0;
            
            if (pdfWriter != null)
            {
                //Rectangle left = new Rectangle(30, currentHeight, 595 / 2 - 30, 842 / 2 - 30);
                //Rectangle right = new Rectangle(595 / 2, currentHeight, 595 - 30, 842 - this.currentHeight + 30);

                columnText.SetSimpleColumn(columns[0, 0], columns[0, 1], columns[0, 2], this.currentHeight);
                Boolean leftside = true;
                
                
                if (tag.Attributes.ContainsKey(mulityColumnAttr) && tag.Attributes[mulityColumnAttr] == "true")
                {
                    Console.WriteLine("处理多栏");
                    try
                    {
                        
                        List<IElement> temp = (List<IElement>) currentContent;
                        List<Chunk> tempChunkList = (List<Chunk>) temp[0].Chunks;
                        Font font = tempChunkList[0].Font;
                        string fontName = font.Familyname;
                        Console.WriteLine("Familyname:" + fontName);
                        
                        foreach (IElement element in temp)
                        {
                            List<Chunk> tempChunks = (List<Chunk>) element.Chunks;//一个元素对应一个标签
                            
                            foreach (Chunk Chunk in tempChunks)
                            {
                                BaseFont bf = Chunk.Font.BaseFont;
                                
                                //Console.WriteLine("Size:" + Chunk.Font.Size);
                                //Console.WriteLine("CalculatedSize:" + Chunk.Font.CalculatedSize);
                                float ascent = bf.GetAscentPoint(Chunk.Content, Chunk.Font.Size);
                                float descent = bf.GetDescentPoint(Chunk.Content, Chunk.Font.Size);
                                float height = ascent - descent;
                                this.columnHeigthCount += height * 2;
                                //Console.WriteLine("height:" + height);
                                Console.WriteLine("Content:" + Chunk.Content);
                            }
                            Console.WriteLine("count:" + this.columnHeigthCount);

                            if (ColumnText.isAllowedElement(element))
                            {
                                columnText.AddElement(element);
                                this.status = columnText.Go();
                                
                                while (ColumnText.HasMoreText(status))
                                {
                                    if (leftside)
                                    {
                                        leftside = false;
                                        Console.WriteLine("准备右侧栏:" + columns[1, 0] + "===" + columns[1, 1] + "===" + columns[1, 2] + "===" + columns[1, 3]);
                                        columnText.SetSimpleColumn(columns[1, 0], columns[1, 1], columns[1, 2], this.currentHeight);
                                        //columnText.SetSimpleColumn(right);
                                        this.columnHeigthCount = 0;
                                    }
                                    else
                                    {
                                        document.NewPage();
                                        this.currentHeight = document.Top;
                                        leftside = true;
                                        Console.WriteLine("准备左侧栏:" + columns[0, 0] + "===" + columns[0, 1] + "===" + columns[0, 2] + "===" + columns[0, 3]);
                                        columnText.SetSimpleColumn(columns[0, 0], columns[0, 1], columns[0, 2], this.currentHeight);
                                        //columnText.SetSimpleColumn(left);
                                        this.columnHeigthCount = 0;
                                    }
                                    
                                    status = columnText.Go();
                                }

                            }
                            
                        }
                        this.currentHeight = columnText.YLine;
                        Console.WriteLine("当前文本框高度:" + this.currentHeight);

                        //pdfWriter.PageEmpty = false;
                        //document.NewPage();
                    }
                    catch(Exception e)
                    {
                       
                    }
                    linesWritten += columnText.LinesWritten;
                }
                else
                {
                    this.currentPagesNumber = pdfWriter.PageNumber;
                    Console.WriteLine("当前页为：" + this.currentPagesNumber);
                    
                    if (this.currentPagesNumber != 1)
                    {
                        columnText.Go();
                        //this.currentHeight = columnText.YLine;
                        Console.WriteLine("columnText.YLine:" + columnText.YLine);
                        columnText.SetSimpleColumn(document.Left, document.Bottom, document.Right, columnText.YLine);
                        //columnText.YLine = document.Top - 80f;
                    }
                    else
                    {
                        columnText.SetSimpleColumn(document.Left, document.Bottom, document.Right, document.Top);
                    }
                    
                    foreach (IElement element in currentContent)
                    {
                        
                        columnText.AddElement(element);
                        //document.Add(element);
                    }
                    columnText.Go();
                    linesWritten += columnText.LinesWritten;
                    this.currentHeight = columnText.YLine;
                    Console.WriteLine("处理单栏" + linesWritten);
                    Console.WriteLine("已写文本的高度为:" + this.currentHeight);
                }
                
            }
            //var retval = base.End(ctx, tag, currentContent);
            //Paragraph p2 = new Paragraph();
            //p2.Add(new Chunk(new DottedLineSeparator()));
            //currentContent.Add(p2);
            //var retval = base.End(ctx, tag, currentContent);
            //document.Close();
            return l;
        }


        
   }
}
