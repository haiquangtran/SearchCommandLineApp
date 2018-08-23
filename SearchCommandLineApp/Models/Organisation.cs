using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    public class Organisation
    {
        public int _id { get; set; }
        public string url { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public string[] domain_names { get; set; }
        public string created_at { get; set; }
        public string details { get; set; }
        public bool shared_tickets { get; set; }
        public string[] tags { get; set; }
    }
}
