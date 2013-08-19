using System;
using System.Configuration;
using System.Text;
using BMC.ARSystem;
using ITSM_Webservice.BusinessEntities.Exceptions;
using ITSM_Webservice.BusinessEntities.Helpers;


namespace ITSM_Webservice.DataAccess
{
    class RemedyDataProvider
    {
        //Fields read data from web.config and get intialized in constructor
        private string _serverName = string.Empty;// AR Server Name
        private string _userName = string.Empty;//AR Server User Name
        private string _password = string.Empty;
        readonly Server _arserver;//AR server Instance
        int _port;

        //constructors
        public RemedyDataProvider()
        {
            ARRequestId = string.Empty;
            try
            {
                _serverName = ConfigurationManager.AppSettings[Resources.ConfigServerName];
                _userName = ConfigurationManager.AppSettings[Resources.ConfigUserName];
                _password = ConfigurationManager.AppSettings[Resources.ConfigPassword];
                _arserver = new Server();
                _port = 7733;
                LogHelper.LogTextInfo(_serverName + _userName + _port, "Enter");
                _arserver.SetServerPort(_port, 390600);
                _arserver.Login(_serverName, _userName, _password, string.Empty);
            }
            catch (ARException objArException)
            {
                LogHelper.LogTextFatal(objArException.Message.ToString(), "Exception");
                throw new CustomError("RemedyAPIError", objArException.Message);
            }
        }

        public RemedyDataProvider(string userName, string password, string arRequestId)
        {
            ARRequestId = string.Empty;
            try
            {
                _serverName = ConfigurationManager.AppSettings[Resources.ConfigServerName];
                _userName = userName;
                _password = password;
                _port = 7733;
                _arserver = new Server();
                StringBuilder logText = new StringBuilder();
                LogHelper.LogTextInfo(_serverName + _userName + _port + arRequestId, "Enter");
                _arserver.SetServerPort(_port, 390600);
                _arserver.Login(_serverName, _userName, _password, string.Empty);
                if (!string.IsNullOrEmpty(arRequestId))
                    ARRequestId = arRequestId;
            }
            catch (ARException objARException)
            {
                LogHelper.LogTextFatal(objARException.Message.ToString(), "Exception");
                throw new CustomError("RemedyAPIError", objARException.Message);
            }
        }

        public RemedyDataProvider(string arRequestId)
            : this()
        {
            ARRequestId = arRequestId;
        }

        //property
        public string ARRequestId { get; set; }

        //methods
        public static void SetFieldList(ref FieldValueList fieldSet, uint fieldID, string fieldValue)
        {
            fieldSet[fieldID] = fieldValue;
        }

        public static void SetFieldList(ref FieldValueList fieldSet, uint fieldID, DateTime fieldValue)
        {
            fieldSet[fieldID] = fieldValue;
        }

        public static void SetFieldList(ref FieldValueList fieldSet, uint fieldID, object fieldValue)
        {
            if (fieldValue != null)
                fieldSet[fieldID] = fieldValue;
        }

        public string CreateFormEntry(string formName, FieldValueList fieldSet)
        {
            LogHelper.LogTextDebug(formName, "Create Request");

            string newRequestID;
            try
            {
                newRequestID = _arserver.CreateEntry(formName, fieldSet);
            }
            catch (ARException objARException)
            {
                LogHelper.LogTextFatal(objARException.Message, "Exception");
                throw new CustomError("RemedyAPIError", objARException.Message);
            }

            LogHelper.LogTextDebug(newRequestID, "Request Created");
            return newRequestID;
        }

        public string SetFormEntry(string formName, FieldValueList fieldSet)
        {
            LogHelper.LogTextDebug(formName, "Update Request");
            try
            {
                _arserver.SetEntry(formName, ARRequestId, fieldSet);
            }
            catch (ARException objARException)
            {
                LogHelper.LogTextFatal(objARException.Message, "Exception");
                throw new CustomError("RemedyAPIError", objARException.Message);
            }

            LogHelper.LogTextDebug(ARRequestId, "Request Updated");
            return ARRequestId;
        }

        public static string RetrieveDiaryField(string diaryField)
        {
            DiaryList objdiaryList = DiaryList.Decode(diaryField);
            return objdiaryList.ToString();
        }

        public EntryFieldValueList GetFormData(string formName, string qualification, EntryListFieldList fieldList)
        {
            EntryFieldValueList fvFormData = new EntryFieldValueList();
            LogHelper.LogTextDebug(formName, "Data Returned");
            try
            {
                if (_arserver.LastReturnCode == 0)
                {
                    fvFormData = _arserver.GetListEntryWithFields(formName, qualification, fieldList, 0, 1000);
                    if (fvFormData.Count == 0)
                        throw new CustomError("NoDataFound", "No data is found for given Incident");
                }

            }
            catch (ARException objARException)
            {
                LogHelper.LogTextFatal(objARException.Message.ToString(), "Exception");
                throw new CustomError("RemedyAPIError", objARException.Message);
            }

            LogHelper.LogTextDebug(formName, "Data Returned");
            return fvFormData;
        }

        public static void SetEntryFieldList(ref EntryListFieldList fieldList, int fieldID)
        {
            fieldList.AddField(fieldID);
        }

    }

    internal class Resources
    {
        public static string ConfigServerName { get; set; }
        public static string ConfigUserName { get; set; }
        public static string ConfigPassword { get; set; }
    }
}
