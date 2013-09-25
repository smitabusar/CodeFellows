using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITSM_Webservice.BusinessEntities.Exceptions
{
    //The class is added so that the errorcode and error message which is passed as "errorcode;errormessage" string 
    //can be separated and used to overrride the default errorcode and errormesage of defined application exceptions like
    //instead of deafult application dataformatexception uses TTformatexception
    public class CustomError : ITSM_WebserviceException
    {
        #region Constructors
        public CustomError()
            :base()
        {
        }
        public CustomError(string errCode,string errDescription)
            :base(errCode,errDescription)
        {

        }
        public CustomError(string errCode,string errDescription, Exception inner)
            : base(errCode,errDescription, inner)
        {
        }
        
        #endregion

        
    }
}
