using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class CustomerTask
    {
        public string external_id { get; set; }
        public string customer_external_id { get; set; }
        public string name { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public List<CustomerTaskGoal> customers { get; set; }
    }

    public class CustomerTaskGoal
    {
        public string product_external_id { get; set; }
        public string type { get; set; }
        public decimal goal_value { get; set; }
    }
}