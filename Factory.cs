using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersManage
{
   internal abstract class  Factory:IFactory
    {
       protected TypeMapper _mapper;

        public T Create<T>() where T : IService
        {
             if(_mapper.ContainsKey(typeof(T)))
             {
              Type target=_mapper[typeof(T)];
              return (T)Activator.CreateInstance(target);
             }
             else
                 return default(T);

        }

        public TypeMapper Mapper
        {
            get
            {
                return _mapper;
            }
            set
            {
                _mapper = value;
            }
        }
    }
}
