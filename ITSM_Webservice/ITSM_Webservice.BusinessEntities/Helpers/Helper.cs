using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace ITSM_Webservice.BusinessEntities.Helpers
{
    public sealed class Helper
    {
        //constructor
        private Helper() { }

        //returns all the propertyname=value pair for a specified object
        public static string GetObjectProperties(Object value)
        {
            PropertyInfo objProperty;
            StringBuilder strProperty = new StringBuilder();
            try
            {
                Type actualType = value.GetType();
                PropertyInfo[] propertyList = actualType.GetProperties();
                for (int index = 0; index < propertyList.Length; index++)
                {
                    objProperty = (PropertyInfo)propertyList[index];
                    strProperty.Append(objProperty.Name + " = " + objProperty.GetValue(value, null) + " ; ");
                }
            }
            catch (System.NullReferenceException ex)
            {
                LogHelper.LogTextError(ex.Message, "TODO");
                throw;
            }

            return strProperty.ToString();
        }

        //returns fully qualified name at a specified level
        public static string GetMethodTypeUpLevel(int frame)
        {
            StackTrace stackTrace = new StackTrace();
            StringBuilder methodDetails = new StringBuilder();
            try
            {
                if (stackTrace.FrameCount > frame)
                {
                    methodDetails.Append(stackTrace.GetFrame(frame).GetMethod().DeclaringType.ToString() + ".");
                    methodDetails.Append(FormatMethodName(stackTrace.GetFrame(frame).GetMethod().ToString()));
                }
            }
            catch
            { throw; }
            return (methodDetails.ToString());
        }

        public static string FormatMethodName(string methodPrototype)
        {
            StringBuilder methodName = new StringBuilder();
            methodName.Append(methodPrototype, methodPrototype.IndexOf(" "), methodPrototype.IndexOf("(") - methodPrototype.IndexOf(" "));
            return methodName.ToString();
        }
    }
}
