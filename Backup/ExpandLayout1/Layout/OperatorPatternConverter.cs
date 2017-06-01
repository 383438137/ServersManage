using System;
using System.Collections.Generic;
using System.Text;
using log4net.Layout.Pattern;
using System.IO;
using log4net.Core;
using TGLog;

namespace TGLog.Layout
{
    /// <summary>
    /// 操作者
    /// </summary>
    internal sealed class OperatorPatternConverter : PatternLayoutConverter
    {
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            LogMessage logMessage = loggingEvent.MessageObject as LogMessage;
            if (logMessage != null)
            {  
                // 将UserName作为日志信息输出
                writer.Write(logMessage.Operator);
            }
        }
    }
}
