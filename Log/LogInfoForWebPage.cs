using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
  internal  class LogInfoForWebPage : IlogInfo
    {
      object __this = null;
     public  LogInfoForWebPage(object _this)
      {
          __this = _this;
          System.Reflection.PropertyInfo requestPro = (_this.GetType()).GetProperty("Request");
          object request = requestPro.GetValue(_this, null);

          System.Reflection.PropertyInfo userHostNamePro = (request.GetType()).GetProperty("UserHostName");
          object userHostName = userHostNamePro.GetValue(request, null);
          MachineName = userHostName.ToString();
          System.Reflection.PropertyInfo userHostAddressPro = (request.GetType()).GetProperty("UserHostAddress");
          object userHostAddress = userHostAddressPro.GetValue(request, null);
          IP = userHostAddress.ToString();
          //System.Reflection.PropertyInfo browserPro = (request.GetType()).GetProperty("Browser");
          //object browser = userHostAddressPro.GetValue(request, null);
          //ApplicationName = browser.ToString();
          ApplicationName=System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
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
