using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Log
{
    internal class Log : ILogService
    {
       protected readonly ILog log;
       static IPAddress localip = null;
       public Log():this("")
       { }
       public Log(string fileName)
       {
           if (string.IsNullOrWhiteSpace(fileName) || !System.IO.File.Exists(fileName))
           {
               fileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
           }

           XmlConfigurator.ConfigureAndWatch(new FileInfo(fileName));
           log = LogManager.GetLogger(typeof(Log));
       }
        public string QueryLogByLogIdXml(string logid)
        {
            throw new NotImplementedException();
        }

        public string QueryLogByLevelXml(string level)
        {
            throw new NotImplementedException();
        }

        public string QueryLogByLoggerXml(string logger)
        {
            throw new NotImplementedException();
        }

        public string QueryLogByTimeSpanXml(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public string QueryLogBeforTimeXml(DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public string QueryLogAfterTimeXml(DateTime startTime)
        {
            throw new NotImplementedException();
        }
        private void  _typeIsEquate(Type type,ref List<string> allType)
        {
            allType.Add(type.FullName);
            if (type.BaseType!=null)
                _typeIsEquate(type.BaseType, ref allType);

        }
        #region ILoggingService 成员
        private void _log(object _this, object _message, Level _level,Exception _exception,Dictionary<string,string> ex=null)
        {
            if (_this == null)
                _this = this;
            List<string> _alltype = new List<string>();
            _typeIsEquate(_this.GetType(),ref  _alltype);
            IlogInfo loginfo = null;
            //网页日志
            if (_alltype.Contains<string>("System.Web.UI.Page"))//_this.GetType().FullName == "System.Web.UI.Page"
            {
                loginfo = new LogInfoForWebPage(_this);
             }
            //模型基类
            else if (_alltype.Contains<string>("MeteoModulesBase.Utility.MeteoModuleBase"))//_this.GetType().BaseType.FullName == "MeteoModulesBase.Utility.MeteoModuleBase"
            {
                loginfo = new LogInfoForAbstractModule(_this);
            }
            else
            {
                loginfo =new LogInfoForCommon(_this);
            }
            LoggingEvent loggingEvent = new LoggingEvent(typeof(Log), log.Logger.Repository, log.Logger.Name, _level, _message, _exception);
            loggingEvent.Properties["ApplicationName"] = loginfo.ApplicationName;
            loggingEvent.Properties["ModuleName"] = loginfo.ModuleName;
            loggingEvent.Properties["TaskName"] = loginfo.TaskName;
            loggingEvent.Properties["IP"] = loginfo.IP;
            loggingEvent.Properties["MachineName"] = loginfo.MachineName;
            if (ex != null)
            {
                foreach (KeyValuePair<string, string> kv in ex)
                {
                    loggingEvent.Properties[kv.Key] = kv.Value;
                }
            
            }
            var repository = LogManager.GetRepository();
            var appenders = repository.GetAppenders();
            var targetApder = appenders.First(p => p.GetType().FullName == "Tools.Log.AdoNetAppenderEx") as Tools.Log.AdoNetAppenderEx;
            if(targetApder!=null)
               targetApder.ReConnect();
            log.Logger.Log(loggingEvent);
        }
        public bool IsDebugEnabled
        {
            get
            {
                return log.IsDebugEnabled;
            }
        }
        public bool IsInfoEnabled
        {
            get
            {
                return log.IsInfoEnabled;
            }
        }
        public bool IsWarnEnabled
        {
            get
            {
                return log.IsWarnEnabled;
            }
        }
        public bool IsErrorEnabled
        {
            get
            {
                return log.IsErrorEnabled;
            }
        }
        public bool IsFatalEnabled
        {
            get
            {
                return log.IsFatalEnabled;
            }
        }
        #endregion


        public void Debug(object _this, object message,Dictionary<string,string> ex=null)
        {
            _log(_this, message, Level.Debug, null, ex);
        }

        public void Info(object _this, object message, Dictionary<string, string> ex = null)
        {
            _log(_this, message, Level.Info, null, ex);
        }

        public void Warn(object _this, object message, Dictionary<string, string> ex = null)
        {
            _log(_this, message, Level.Warn, null, ex);
        }

        public void Warn(object _this, object message, Exception exception, Dictionary<string, string> ex = null)
        {
            _log(_this, message, Level.Warn, exception, ex);
        }

        public void Error(object _this, object message, Exception exception, Dictionary<string, string> ex = null)
        {
            _log(_this, message, Level.Error, exception, ex);
        }

        public void Fatal(object _this, object message, Exception exception, Dictionary<string, string> ex = null)
        {
            _log(_this, message, Level.Fatal, exception, ex);
        }
    }
}
