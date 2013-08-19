using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSM_WS.RequsetResponseDataType
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://corp.mycompany.com/WebServices/ITSM_Webservice/")]
    public class GetIncidentResponse
    {
        #region memberVariables
        private string _incidentNumber;
        private string _customer;
        private string _summary;
        private string _impact;
        private string _urgency;
        private string _assignedGroup;
        #endregion

        #region Properties
        public string IncidentNumber
        {
            get { return _incidentNumber; }
            set { _incidentNumber = value; }
        }

        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public string Impact
        {
            get { return _impact; }
            set { _impact = value; }
        }

        public string Urgency
        {
            get { return _urgency; }
            set { _urgency = value; }
        }

        public string AssignedGroup
        {
            get { return _assignedGroup; }
            set { _assignedGroup = value; }
        }

        #endregion
    }
}