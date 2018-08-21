using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    public class User
    {
        public int _id { get; set; }
        public string url { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string created_at { get; set; }
        public bool active { get; set; }
        public bool verified { get; set; }
        public bool shared { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public string last_login_at { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string signature { get; set; }
        public int organization_id { get; set; }
        public string[] tags { get; set; }
        public bool suspended { get; set; }
        public string role { get; set; }
    }
}
