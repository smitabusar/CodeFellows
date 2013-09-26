using System;
using ITSM_Webservice.BusinessEntities.Exceptions;
using ITSM_Webservice.BusinessEntities.Helpers;
using BMC.ARSystem;

namespace ITSM_Webservice.DataAccess
{
    public class IncidentDataProvider
    {
        public EntryFieldValueList GetIncident(string incidentNumber)
        {
            LogHelper.LogTextDebug(incidentNumber, "Enter");
            EntryListFieldList fvFieldList;
            EntryFieldValueList fvIncident;

            string qual = string.Empty;
            try
            {
                if (!String.IsNullOrEmpty(incidentNumber))
                    qual = "'IncidentNumber' = \"" + incidentNumber + "\"";
                fvFieldList = CreateIncidentFieldList();
                fvIncident = new RemedyDataProvider().GetFormData("HPD:Help Desk", qual, fvFieldList);
            }
            catch (CustomError ex)
            {
                LogHelper.LogTextWarn(ex.Message, "Exception");
                throw;
            }

            LogHelper.LogTextDebug(incidentNumber, "Incident Returned");
            return fvIncident;
        }

        private EntryListFieldList CreateIncidentFieldList()
        {
            EntryListFieldList fvFieldList = new EntryListFieldList();
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000161);//IncidentNumber
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000000);//Summary
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000151);//Notes
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 7);//Status
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000163);//Impact
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000162);//Urgency
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000164);//Priority
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000018);//LastName
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000019);//FirstName
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000099);//IncidentType
            RemedyDataProvider.SetEntryFieldList(ref fvFieldList, 1000000217);//Assigned Group           
            return fvFieldList;
        }
    }
}
