using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace ITSM_Webservice.BusinessEntities.Exceptions
{
    [Serializable]
    public abstract class ITSM_WebserviceException : ApplicationException
    {
        #region Constructors
        protected ITSM_WebserviceException()
            : base()
        {
        }

        protected ITSM_WebserviceException(string error, string errorDesc)
            : base(string.Concat(error,";",errorDesc))
        {
            ErrorCode=error;
            ErrorDescription=errorDesc;
        }

        protected ITSM_WebserviceException(string error, string errorDesc, Exception inner)
            : base(string.Concat(error, ";", errorDesc), inner)
        {
            ErrorCode = error;
            ErrorDescription = errorDesc;
        }

        protected ITSM_WebserviceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        private string errorCode;
        private string errorDescription;

        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        public string ErrorDescription
        {
            get { return errorDescription; }
            set { errorDescription = value; }
        }
    }
}
