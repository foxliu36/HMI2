using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//http://support.microsoft.com/kb/307548/zh-tw
namespace Lib
{
    public class XmlProfile
    {

        private XmlTextReader reader;

        public XmlProfile(string p_File) 
        {
            reader = new XmlTextReader(p_File);
        }

        public XmlProfile(string p_Text, string type)
        {
            reader = new XmlTextReader(p_Text, XmlNodeType.Element, null);
        }

        public XmlTextReader GetXmlReader() 
        {
            return reader;
        } 

    }
}
