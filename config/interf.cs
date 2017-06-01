using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tools.config
{

   public  class interf
    {
       [XmlAttribute("type")]
       public string TypeName;
       [XmlArrayItem("imp")]
       public List<imp> imps = new List<imp>();
    }
    public class imp
    {
    [XmlAttribute("active")]
     public string Active;
    [XmlAttribute("type")]
    public string Type;
   }
}
