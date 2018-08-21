using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    public class Ticket
    {
        public string _id { get; set; }
        public string url { get; set; }
        public string external_id { get; set; }
        public string created_at { get; set; }
        public string type { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public int submitter_id { get; set; }
        public int assignee_id { get; set; }
        public int organization_id { get; set; }
        public string[] tags { get; set; }
        public bool has_incidents { get; set; }
        public string due_at { get; set; }
        public string via { get; set; }
    }
}
