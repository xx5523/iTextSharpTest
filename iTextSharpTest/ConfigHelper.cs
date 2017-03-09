using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using iTextSharp.text;

namespace iTextSharpTest
{
    public struct HTMLTemplateConfig
    {
        public string configName;//书籍名称
        public string htmlSourceFileName;//文件名称
        public string edition;
        public float pageMarginLeft;
        public float pageMarginRight;
        public float pageMarginTop;
        public float pageMarginBottom;
        public int floorCount;//层次
        public Rectangle rectangle;
    }

    class ConfigHelper
    {
        private LinkedList<HTMLTemplateConfig> configList;

        ConfigHelper()
        {
            
        }


        private void SaveConfig(string ConnenctionString)
        {

            XmlDocument xmlDocument = new XmlDocument();

            //获得配置文件的全路径
            string fileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Code.exe.config";

            xmlDocument.Load(fileName);

            //找出名称为“htmlFileConfig”的所有元素
            XmlNodeList nodes = xmlDocument.GetElementsByTagName("htmlFileConfig");

            for (int i = 0; i < nodes.Count; i++)
            {

                //获得将当前元素的key属性
                XmlAttribute att = nodes[i].Attributes["key"];

                //根据元素的第一个属性来判断当前的元素是不是目标元素
                if (att.Value == "ConnectionString")
                {
                    //对目标元素中的第二个属性赋值
                    att = nodes[i].Attributes["value"];
                    att.Value = ConnenctionString;
                    break;
                }
            }

            //保存上面的修改
            xmlDocument.Save(fileName);

        }


        public void readConfigFile(String path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (Directory.Exists(path))
            {
                readConfigDirectory(path);
            }
            else
            {
                //获得配置文件的全路径
                if (path != null)
                {
                    xmlDocument.Load(path);
                    XmlNodeList nodes = xmlDocument.GetElementsByTagName("book");
                    for (int i = 0; i < nodes.Count; i++)
                    {

                        HTMLTemplateConfig htmlTemplateConfig;
                        htmlTemplateConfig.htmlSourceFileName = path;
                        //XmlNodeList nodes = nodes.GetEnumerator();
                       // htmlTemplateConfig.configName = 

 
                    }
                    
                }
            }
        }


        public void readConfigDirectory(String path)
        {
            String[] childFileName = Directory.GetFiles(path);
        }
    }

}
