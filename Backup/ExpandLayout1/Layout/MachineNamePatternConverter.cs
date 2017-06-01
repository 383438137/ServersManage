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
    /// 机器名
    /// </summary>
    internal sealed class MachineNamePatternConverter : PatternLayoutConverter
    {
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            LogMessage logMessage = loggingEvent.MessageObject as LogMessage;
            if (logMessage != null)
            {
                writer.Write(logMessage.MachineName);
            }
        }
    }
}
