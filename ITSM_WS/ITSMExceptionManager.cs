using System.Web.Services.Protocols;
using System.Xml;
using ITSM_Webservice.BusinessEntities.Exceptions;
namespace ITSM_WS
{
    public class ITSMExceptionManager
    {
        public static SoapException GetCustomSoapException(ITSM_WebserviceException ex)
        {
            return GetCustomSoapException(ex.ErrorCode, ex.ErrorDescription);

        }

        public static SoapException GetCustomSoapException(string errorCode, string errorDescription)
        {
            XmlDocument faultDoc = new XmlDocument();
            XmlNode detailNode = faultDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            XmlNode faultNode = faultDoc.CreateNode(XmlNodeType.Element, "ns", "ServiceFault", "http://corp.mycompany.com/WebServices/ITSM_Webservice/");
            XmlNode errorCodeNode = faultDoc.CreateNode(XmlNodeType.Element, "ErrorCode", string.Empty);
            XmlNode errorDescriptionNode = faultDoc.CreateNode(XmlNodeType.Element, "ErrorDescription", string.Empty);

            errorCodeNode.InnerText = errorCode;
            errorDescriptionNode.InnerText = errorDescription;
            faultNode.AppendChild(errorCodeNode);
            faultNode.AppendChild(errorDescriptionNode);
            detailNode.AppendChild(faultNode);

            SoapException se = new SoapException("Error occurred at", SoapException.ClientFaultCode, "ITSM_WebService ITSM_Webservice", detailNode);
            return se;
        }
    }
}