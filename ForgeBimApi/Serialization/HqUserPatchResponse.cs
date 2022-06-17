using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.Forge.BIM360.Serialization
{
    public class HqUserPatchResponse
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
