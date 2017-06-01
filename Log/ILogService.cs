using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public interface ILogService : IService
    {


        string QueryLogByLogIdXml(string logid);
        string QueryLogByLevelXml(string level);
        string QueryLogByLoggerXml(string logger);
        string QueryLogByTimeSpanXml(DateTime startTime, DateTime endTime);
        string QueryLogBeforTimeXml(DateTime endTime);
        string QueryLogAfterTimeXml(DateTime startTime);

        void Debug(object _this,object message,Dictionary<string,string> ex=null);
        void Info(object _this, object message, Dictionary<string, string> ex = null);
        void Warn(object _this, object message, Dictionary<string, string> ex = null);
        void Warn(object _this, object message, Exception exception, Dictionary<string, string> ex = null);
        void Error(object _this, object message, Exception exception, Dictionary<string, string> ex = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_this">传THIS进来,本类的参数</param>
        /// <param name="message">信息</param>
        /// <param name="exception">意外对象</param>
        void Fatal(object _this, object message, Exception exception, Dictionary<string, string> ex = null);

        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
    }
}
