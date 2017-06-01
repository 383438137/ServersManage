using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools.config;

namespace Tools
{
    public class Class1
    {
        static void Main(string[] args)
        {

            Assembly assemblyObj = Assembly.GetExecutingAssembly();
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            string _namespace = type.Namespace;
            string fullNameSpace = string.Format("{0}.{1}.{2}", _namespace, "config", "Assembly.xml");
            Stream _stream = assemblyObj.GetManifestResourceStream(fullNameSpace);
           // _stream.Position = 0;
           // StreamReader reader = new StreamReader(_stream);
          //  string text = reader.ReadToEnd();
             List<interf> list = XmlHelper.XmlDeserialize<List<interf>>(_stream, Encoding.UTF8);
            //List<interf> list = XmlHelper.XmlDeserialize<List<interf>>(text, Encoding.UTF8);

            //interf command = new interf();
            //command.TypeName = "InsretCustomer";
            //command.imps.Add(new imp {Type = "Name1", Active = "true" });
            //command.imps.Add(new imp { Type = "Name2", Active = "false" });

            //List<interf> list = new List<interf>(1);
            //list.Add(command);

            //XmlHelper.XmlSerializeToFile(list, @"F:\aa.xml", Encoding.UTF8);
        }
    }
}
