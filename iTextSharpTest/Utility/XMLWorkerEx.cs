using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.tool.xml;

namespace iTextSharpTest.Utility
{
    class XMLWorkerEx : XMLWorker
    {
        public XMLWorkerEx(IPipeline pipeline, bool parseHtml) : base(pipeline, parseHtml)
        {

        }

        public override void StartElement(String tag, IDictionary<String, String> attr, String ns)
        {
            Console.WriteLine("tag:" + tag);
            foreach (var item in attr)
            {
                Console.WriteLine(item.Key + item.Value);

            }
            base.StartElement(tag, attr, ns);
        }
    }
}
