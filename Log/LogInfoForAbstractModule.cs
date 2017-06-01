using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
  internal  class LogInfoForAbstractModule : IlogInfo
    {
      object __this = null;
      public LogInfoForAbstractModule(object _this)
      {
          __this = _this;
          IPAddress localid = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
          MachineName = System.Net.Dns.GetHostName();
          IP = localid.ToString();
          ApplicationName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;

          System.Reflection.PropertyInfo modelPro = (_this.GetType()).GetProperty("Model");
          object modelVal = modelPro.GetValue(_this, null);

          System.Reflection.PropertyInfo taskPro = (_this.GetType()).GetProperty("Caption");
          object taskVal = taskPro.GetValue(_this, null);

          System.Reflection.PropertyInfo guidPro = (_this.GetType()).GetProperty("GUID");
          object guidVal = guidPro.GetValue(_this, null);


          System.Reflection.PropertyInfo idPro = (_this.GetType()).GetProperty("GUID");
          object idVal = idPro.GetValue(_this, null);

          System.Reflection.PropertyInfo namePro = (modelVal.GetType()).GetProperty("Name");
          object nameVal = namePro.GetValue(modelVal, null);
          TaskName = nameVal.ToString();
          ModuleName = taskVal.ToString();
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
