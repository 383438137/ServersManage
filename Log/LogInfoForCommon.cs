using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
  internal  class LogInfoForCommon : IlogInfo
    {
      object __this = null;
      public LogInfoForCommon(object _this)
      {
          __this = _this;
          IPAddress localid = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
          MachineName = System.Net.Dns.GetHostName();
          IP = localid.ToString();
          ApplicationName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
      }
      public string ApplicationName
      {
          get;
          set;
      }

        public string ModuleName
        {
            get;
            set;
        }

        public string TaskName
        {
            get;
            set;
        }

        public string IP
        {
            get;
            set;
        }

        public string MachineName
        {
            get;
            set;
        }
    }
}
