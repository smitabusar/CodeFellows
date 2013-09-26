using System;
using ITSM_WS.RequsetResponseDataType;
using ITSM_Webservice.BusinessEntities;
using ITSM_Webservice.BusinessEntities.Helpers;

namespace ITSM_WS.Translators
{
    public class TranslateIncident
    {
        public GetIncidentResponse TranslateIncidenttoGetIncidentResponse(Incident objIncident)
        {
            LogHelper.LogTextDebug(string.Empty, "Enter");
            LogHelper.LogObjectPropertiesDebug(objIncident, "IncidentDetails");
            GetIncidentResponse objGetIncidentResponse = new GetIncidentResponse();
            try
            {
                if (objIncident != null)
                {
                    objGetIncidentResponse.IncidentNumber = objIncident.IncidentNumber;
                    objGetIncidentResponse.Impact = objIncident.Impact;
                    objGetIncidentResponse.Customer = objIncident.Customer;
                    objGetIncidentResponse.AssignedGroup = objIncident.AssignedGroup;
                    objGetIncidentResponse.Summary = objIncident.Summary;
                    objGetIncidentResponse.Urgency = objIncident.Urgency;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogTextWarn(ex.Message, "Exception");
                throw;
            }
            LogHelper.LogTextDebug(string.Empty, "Exit");
            return objGetIncidentResponse;
        }

    }
}