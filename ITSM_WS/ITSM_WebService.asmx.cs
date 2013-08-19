using System;
using System.Web.Services;
using ITSM_WS.RequsetResponseDataType;
using ITSM_WS.Translators;
using ITSM_Webservice.BusinessEntities.Helpers;
using ITSM_Webservice.BusinessEntities.Exceptions;
using ITSM_Webservice.BusinessEntities;
using ITSM_WebService.BusinessLogic;


namespace ITSM_WS
{
    /// <summary>
    /// Summary description ITSM_WebService
    /// </summary>
    [WebService(Name="ITSM_WebService", Namespace = "http://corp.mycompany.com/WebServices/ITSM_Webservice/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ITSMService : System.Web.Services.WebService
    {

        [WebMethod]
        public GetIncidentResponse GetIncident(GetIncidentRequest objGetIncidentRequest)
        {
            LogHelper.LogTextDebug("", "Enter");
            LogHelper.LogObjectPropertiesDebug(objGetIncidentRequest, "IncidentRequest");
            Incident objIncident = null;

            try
            {
                GetIncidentResponse objGetIncidentResponse = null;
                if (string.IsNullOrEmpty(objGetIncidentRequest.IncidentNumber))
                {
                    throw new CustomError("NullData","Incident Number is null");
                }
                else
                {
                    objIncident = new IncidentController().GetIncident(objIncident.IncidentNumber);
                    objGetIncidentResponse = new TranslateIncident().TranslateIncidenttoGetIncidentResponse(objIncident);
                }
                LogHelper.LogTextDebug("Success", "Returning Incident Response");
                return objGetIncidentResponse;
            }
            catch (ITSM_WebserviceException ex )
            {
                LogHelper.LogTextWarn(string.Format("Message : {0}\nError : {1}\nStack Trace : {2}", ex.Message, ex.ErrorCode, ex.StackTrace), "Exception");
                throw ITSMExceptionManager.GetCustomSoapException(ex);
            }
            catch (Exception ex)
            {
                LogHelper.LogTextWarn(string.Format("Message : {0}\nStack Trace : {2}", ex.Message, ex.StackTrace), "Exception");
                throw ITSMExceptionManager.GetCustomSoapException("Unknown Error", ex.Message);
            }
            
        }
    }
}