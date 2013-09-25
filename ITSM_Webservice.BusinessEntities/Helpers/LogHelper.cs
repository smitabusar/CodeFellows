using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace ITSM_Webservice.BusinessEntities.Helpers
{
    //Class with static members should have private constructor and be sealed class
    public sealed class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int frame = 2;//for getting methodname which is grandparent of GetMethodTypeUpLevel

        //constructor
        private LogHelper() { }

        public static void LogTextFatal(string logText, string status)
        {
            if (log.IsFatalEnabled)
            {
                using (log4net.NDC.Push(string.Format(status, Helper.GetMethodTypeUpLevel(frame))))
                {
                    log.Fatal(logText);
                }
            }
        }

        public static void LogTextError(string logText, string status)
        {
            if (log.IsErrorEnabled)
            {
                using (log4net.NDC.Push(string.Format(status, Helper.GetMethodTypeUpLevel(frame))))
                {
                    log.Error(logText);
                }
            }
        }

        public static void LogTextWarn(string logText, string status)
        {
            if (log.IsWarnEnabled)
            {
                using (log4net.NDC.Push(string.Format(status, Helper.GetMethodTypeUpLevel(frame))))
                {
                    log.Warn(logText);
                }
            }
        }

        public static void LogTextInfo(string logText, string status)
        {
            if (log.IsInfoEnabled)
            {
                using (log4net.NDC.Push(string.Format(status, Helper.GetMethodTypeUpLevel(frame))))
                {
                    log.Info(logText);
                }
            }
        }

        public static void LogTextDebug(string logText, string status)
        {
            if (log.IsDebugEnabled)
            {
                using (log4net.NDC.Push(string.Format(status, Helper.GetMethodTypeUpLevel(frame))))
                {
                    log.Debug(logText);
                }
            }
        }

        public static void LogObjectPropertiesDebug(Object value, string objectName)
        {
            if (log.IsDebugEnabled)
            {
                using (log4net.NDC.Push(string.Format("Properties of {0} Object in {1} method", objectName, Helper.GetMethodTypeUpLevel(frame))))
                {
                    StringBuilder ObjProperties = new StringBuilder();
                    ObjProperties.AppendLine(Helper.GetObjectProperties(value));
                    log.Debug(ObjProperties.ToString());
                }
            }
        }

        
    }
}
