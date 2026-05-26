using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class Target
    {
        public string external_id { get; set; }
        public string name { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public bool is_enabled { get; set; }
        public decimal percentage_realization { get; set; }
        public bool is_task { get; set; }
        public bool is_done { get; set; }
        public int action_type { get; set; }
        public string period { get; set; }
        public List<TargetGoal> goals { get; set; }
        public List<TargetAssignment> assignments { get; set; }
        public List<TargetSalesRepresentative> sales_representatives { get; set; }
    }

    public class TargetGoal
    {
        public string external_id { get; set; }
        public string type { get; set; }
        public decimal goal_value { get; set; }
        public string product_external_id { get; set; }
        public string product_category_external_id { get; set; }
}

    public class TargetAssignment
    {
        public string external_id { get; set; }
        public string customer_external_id { get; set; }
        public string customer_category_external_id { get; set; }
        public string target_goal_external_id { get; set; }
    }

    public class TargetSalesRepresentative
    {
        public string external_id { get; set; }
        public string identifier { get; set; }
        public string keycloak_id { get; set; }
        public string target_goal_external_id { get; set; }
    }
}
