using System;

namespace Amplifier
{
    public class SchedulerEntry
    {
        public string external_id { get; set; }
        public string name { get; set; }
        public string customer { get; set; }
        public string cron_expression { get; set; }
        public string related_user_login { get; set; }
        public string sales_representative { get; set; }
        public bool is_enabled { get; set; }
        public string updatable_fields = "";
        public DateTime entry_date { get; set; }
        public DateTime? ended_at { get; set; }
        public DateTime? ex_dates { get; set; }        
    }
}