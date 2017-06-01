using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
   public  class ServicesManage
    {
       private static readonly Dictionary<Type, object> types = new Dictionary<Type, object>();
      public   static T GetService<T>(){
          Type _type=typeof(T);
          if (types.ContainsKey(_type))
              return (T)types[_type];
          else
          {
              T _t=AssemblyMechanism.CreateInstance<T>();
              types.Add(_type,_t);
              return _t;
          }
      }
    }
}
