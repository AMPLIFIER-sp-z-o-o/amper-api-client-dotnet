using System;

namespace Amplifier
{
    public class Promotion
    {

        public string external_id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int priority { get; set; }
        public string description { get; set; }
        public string short_code { get; set; }
        public bool is_enabled { get; set; }
    }

    public class PromotionCustomer
    {
        public string external_id { get; set; }
        public string promotion_external_id { get; set; }
        public string customer_external_id { get; set; }
    }

    public class PromotionCustomerCategory
    {
        public string external_id { get; set; }
        public string promotion_external_id { get; set; }
        public string customer_category_external_id { get; set; }
    }
}