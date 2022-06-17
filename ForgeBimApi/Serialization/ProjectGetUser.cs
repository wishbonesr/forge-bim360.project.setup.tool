using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Forge.BIM360.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InclInExportAttribute : System.Attribute
    {
        public bool include = true;
        public InclInExportAttribute(bool include = true)
        {
            this.include = include;
        }
    }
    public class ProjectGetUser
    {
        [JsonIgnore]
        public string projectId { get; set; }
        [JsonIgnore]
        public string projectName { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string stateOrProvince { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string imageUrl { get; set; }
        //public string phone { get; set; }
        public string jobTitle { get; set; }
        public string industry { get; set; }
        public string aboutMe { get; set; }
        public string companyId { get; set; }
        public string status { get; set; }
        public DateTime addedOn { get; set; }
        [InclInExport(false)]
        public Accesslevels accessLevels { get; set; }
        [InclInExport(false)]
        public Service[] services { get; set; }
        public string[] roleIds { get; set; }
        [InclInExport(false)]
        public Product[] products { get; set; }
        [JsonIgnore]
        public string projectAdministration
        {
            get
            {
                string serviceName = "projectAdministration";
                string aLevel = "";
                if (services != null)
                    foreach (Service s in services)
                    {
                        if (s.serviceName == serviceName)
                        {
                            aLevel = s.access;
                        }
                    }
                return aLevel;
            }
        }
        [JsonIgnore]
        public string documentManagement
        {
            get
            {
                string serviceName = "documentManagement";
                string aLevel = "";
                if (services != null)
                    foreach (Service s in services)
                    {
                        if (s.serviceName == serviceName)
                        {
                            aLevel = s.access;
                        }
                    }
                return aLevel;
            }
        }
        [JsonIgnore]
        public string insight
        {
            get
            {
                string serviceName = "insight";
                string aLevel = "";
                if (services != null)
                    foreach (Service s in this.services)
                    {
                        if (s.serviceName == serviceName)
                        {
                            aLevel = s.access;
                        }
                    }
                return aLevel;
            }
        }
        [JsonIgnore]
        public bool accountAdmin { get { return this.accessLevels.accountAdmin; } }
        [JsonIgnore]
        public bool executive { get { return this.accessLevels.executive; } }
        [JsonIgnore]
        public bool projectAdmin { get { return this.accessLevels.projectAdmin; } }
        #region Constructor
        //public ProjectGetUser()
        //{
        //    services = new List<Service>();
        //}
        #endregion
    }

    public class Accesslevels
    {
        public bool accountAdmin { get; set; }
        public bool projectAdmin { get; set; }
        public bool executive { get; set; }
    }

    public class Service
    {
        public string serviceName { get; set; }
        public string access { get; set; }
    }

    public class Product
    {
        public string key { get; set; }
        public string productKey { get; set; }
        public string access { get; set; }
    }

    public enum ProjectServiceLevels { none, memeber, administration };

}
