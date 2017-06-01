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
    internal class AssemblyMechanism
    {
        private static TypeMapper _dictionary = new TypeMapper();
        static AssemblyMechanism()
        {
            Assembly assemblyObj = Assembly.GetExecutingAssembly();
         
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            string _namespace = type.Namespace;
            string fullNameSpace = string.Format("{0}.{1}.{2}", _namespace, "config", "Assembly.xml");
            Stream _stream = assemblyObj.GetManifestResourceStream(fullNameSpace);
            List<interf> list = XmlHelper.XmlDeserialize<List<interf>>(_stream, Encoding.UTF8);
            foreach (interf i in list)
            {
                if (!String.IsNullOrEmpty(i.TypeName))
                {
                    string[] _typeArray = i.TypeName.Split(',');
                    if (_typeArray.Length == 2)
                    {
                      
                        Type interfaceType = assemblyObj.GetType(_typeArray[0], false, true);
                        imp _imp = i.imps.Where<imp>(t => t.Active.ToLower() == "true").FirstOrDefault<imp>();

                        Type impType = null;
                        if (_imp.Type.Split(',').Length == 2)
                        {
                           impType= assemblyObj.GetType(_imp.Type.Split(',')[0], false, true);
                        }
                        _dictionary.Add(interfaceType, impType);
                    }
                }
            }
        }
        public static T CreateInstance<T>()
        {
            if(_dictionary.ContainsKey(typeof(T)))
            {
                Type target=_dictionary[typeof(T)];
                return (T)Activator.CreateInstance(target);
            }
            else
                return default(T);
        }
    }
}