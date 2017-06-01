using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
    public class AdoNetAppenderEx : log4net.Appender.AdoNetAppender
    {
        public AdoNetAppenderEx():base()
        {
          
        }

        public void ReConnect()
        {
            try
            {
                System.Data.IDbConnection c = base.Connection;
                if (c != null && c.State == System.Data.ConnectionState.Closed)
                    c.Open();
            }
            catch(Exception e)
            {
            
            }
        }
    }
}
