using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersManage
{
    interface IFactory
    {
        T Create<T>() where T : IService;
        TypeMapper Mapper {get;set; }
    }
}
