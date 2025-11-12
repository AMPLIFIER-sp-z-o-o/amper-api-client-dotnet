using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifier
{    
    public class ComplaintLine
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public string purchase_date { get; set; }
        public string order { get; set; }
        public string description { get; set; }
        public int complaint { get; set; }
        public string product_external_id { get; set; }
        public decimal quantity { get; set; }
    }

    public class Complaint
    {
        public int id { get; set; }
        public List<ComplaintLine> lines { get; set; }
        public List<object> attachments { get; set; }
        public List<object> notes { get; set; }
        public string number { get; set; }
        public string note { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Customer? updated_by { get; set; }
        public Customer? created_by { get; set; }
        public string customer_external_id { get; set; }
        public Customer? customer { get; set; }
        public object correction_type { get; set; }
        public string sales_rep_username { get; set; }
    }
}
