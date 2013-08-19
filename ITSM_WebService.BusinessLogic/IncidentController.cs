using System;
using ITSM_Webservice.BusinessEntities.Helpers;
using ITSM_Webservice.BusinessEntities.Exceptions;
using ITSM_Webservice.BusinessEntities;
using ITSM_Webservice.DataAccess;
using BMC.ARSystem;

namespace ITSM_WebService.BusinessLogic
{
    public class IncidentController
    {
        public Incident GetIncident(string incidentNumber)
        {
            LogHelper.LogTextDebug(incidentNumber,"Enter");
            Incident objIncident;
            try
            {
                if (incidentNumber == String.Empty)
                    throw new CustomError("NullID","Incident Number is null");
                objIncident = FillIncident(incidentNumber);
            }
            catch (CustomError ex)
            {
                LogHelper.LogTextWarn(ex.Message, "Exception");
                throw;
            }

            LogHelper.LogTextDebug(string.Empty, "Exit");
            return objIncident;
        }

        private Incident FillIncident(string incidentNumber)
        {
            LogHelper.LogTextDebug(incidentNumber, "Enter");
            Incident objIncident = null;
            try
            {
                objIncident = new Incident();
                objIncident.IncidentNumber = incidentNumber;
                EntryFieldValueList fvIncident = new EntryFieldValueList();
                fvIncident = new IncidentDataProvider().GetIncident(incidentNumber);
                if (fvIncident!=null)
                {
                    objIncident.IncidentNumber = fvIncident[0].FieldValues[1000000161].ToString();
                    objIncident.Customer = fvIncident[0].FieldValues[1000000019].ToString() + " " + fvIncident[0].FieldValues[1000000018].ToString();
                    objIncident.AssignedGroup = fvIncident[0].FieldValues[1000000217].ToString();
                    objIncident.Impact= fvIncident[0].FieldValues[1000000163].ToString();
                    objIncident.Summary = fvIncident[0].FieldValues[1000000000].ToString();
                    objIncident.Urgency= fvIncident[0].FieldValues[1000000162].ToString();
                }
                else
                    throw new CustomError("InvalidID","Incident Number not found");
            }
            catch (System.NullReferenceException ex)
            {
                LogHelper.LogTextWarn(ex.Message, "Exception");
                throw;
            }
            catch (CustomError ex)
            {
                LogHelper.LogTextWarn(ex.Message, "Exception");
                throw;
            }
            return objIncident;
        }
        

    }
}
