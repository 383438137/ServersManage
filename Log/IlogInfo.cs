using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
    interface IlogInfo
    {
         string ApplicationName { get; set; }
         string ModuleName { get; set; }
         string TaskName { get; set; }
         string IP { get; set; }
         string MachineName { get; set; } 

    }
}
