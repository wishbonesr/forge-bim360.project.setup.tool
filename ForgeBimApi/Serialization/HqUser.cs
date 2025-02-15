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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Autodesk.Forge.BIM360.Serialization
{
    public class HqUser : UserBase
    {
        [JsonIgnore]
        public string full_name {
            get { return this.first_name + " " + this.last_name; }
        }

        public string id { get; set; }
        public string uid { get; set; }
        public string company_name { get; set; }
        public string account_id { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime last_sign_in { get; set; }

        public string phone { get; set; }
    }

    public class UpUser
    {
        [JsonIgnore]
        public string id { get; set; }
        [JsonIgnore]
        public string email { get; set; }
        public string company_id { get; set; }
        public string status { get; set; }
    }
}
