/////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved
// Written by Forge Partner Development
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM 'AS IS' AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//used for post project user responses
namespace Autodesk.Forge.BIM360.Serialization
{
    public class Services
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DocumentManagement document_management;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ProjectAdministration project_administration;
    }

    public class ProjectAdministration
    {
        public ProjectAdministration() { }
        [JsonConverter(typeof(StringEnumConverter))]
        public AccessLevel access_level; // only allowed values are "admin" or "user"
    }

    public class DocumentManagement : ProjectAdministration
    {
    }

    public enum AccessLevel { admin, user };

}
