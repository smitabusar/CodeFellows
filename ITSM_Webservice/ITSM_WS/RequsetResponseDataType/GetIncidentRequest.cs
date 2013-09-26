using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSM_WS.RequsetResponseDataType
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://corp.mycompany.com/WebServices/ITSM_Webservice/")]
    public class GetIncidentRequest
    {
        private string _incidentNumber;

        /// <remarks/>
        public string IncidentNumber
        {
            get
            {
                return this._incidentNumber;
            }
            set
            {
                this._incidentNumber = value;
            }
        }
    }
}