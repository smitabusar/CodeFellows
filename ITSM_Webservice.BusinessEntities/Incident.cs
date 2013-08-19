namespace ITSM_Webservice.BusinessEntities
{
    public class Incident
    {
        public string IncidentNumber { get; set; }

        public string Customer { get; set; }

        public string Summary { get; set; }

        public string Impact { get; set; }

        public string Urgency { get; set; }

        public string AssignedGroup { get; set; }
    }
}
