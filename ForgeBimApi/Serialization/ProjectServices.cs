//#nullable enable
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//used for get project users which has different attribute name spelling
namespace Autodesk.Forge.BIM360.Serialization
{
    public class ProjectServices
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ProjectServiceAccess projectAdministration;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess costManagement;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess designCollaboration;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ProjectServiceAccess documentManagement;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess field;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess fieldManagement;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess assets;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess glue;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ProjectServiceAccess insight;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess modelCoordination;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess plan;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProjectServiceAccess projectManagement;
    }

    public class ProjectServiceAccess
    {
        public ProjectServiceAccess() { }
        [JsonConverter(typeof(StringEnumConverter))]
        public AccessLevelGet access;
    }
    //public class CostManagementGet : ProjectAdministrationGet { }
    //public class designCollaborationGet : ProjectAdministrationGet { }
    //public class documentManagementGet : ProjectAdministrationGet { }
    //public class fieldGet : ProjectAdministrationGet { }
    //public class fieldManagementGet : ProjectAdministrationGet { }
    //public class assetsGet : ProjectAdministrationGet { }
    //public class glueGet : ProjectAdministrationGet { }
    //public class insightGet : ProjectAdministrationGet { }
    //public class modelCoordinationGet : ProjectAdministrationGet { }
    //public class planGet : ProjectAdministrationGet { }
    //public class projectManagementGet : ProjectAdministrationGet { }

    public enum AccessLevelGet { none, memeber, administration};
}
