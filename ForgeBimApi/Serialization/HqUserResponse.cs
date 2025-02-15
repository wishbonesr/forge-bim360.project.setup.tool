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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.Forge.BIM360.Serialization
{
    public class HqUserResponse : ResponseStats
    {
        public List<HqUser> success_items;
        public List<HqUserFailureItem> failure_items;
    }

    public class HqUserFailureItem
    {
        public HqUser item;
        public string error;
    }

    public class HqUpdateUserResponse
    {
        public string account_id;
        public string status;
        public string role;
        public string company_id;
        public string company_name;
        public string email;
        public string name;
        public string nickname;
        public string first_name;
        public string last_name;
        public string uid;
        public string image_url;
        public string address_line_1;
        public string address_line_2;
        public string city;
        public string postal_code;
        public string state_or_province;
        public string country;
        public string phone;
        public string company;
        public string job_title;
        public string industry;
        public string about_me;
        public ResponseContent[] error;
    }
}
