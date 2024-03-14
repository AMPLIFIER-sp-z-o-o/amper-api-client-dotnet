using System;

namespace Amplifier
{
    public class Promotion
    {
        public int? id { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public int? priority { get; set; }
        public string description { get; set; }
        public string short_code { get; set; }
        public bool? is_enabled { get; set; }
        public string updatable_fields = "";
        public string external_identifier { get; set; }
        public string internal_description { get; set; }
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
    
    public class ConditionRelation
    {
        public string external_id { get; set; }
        public string promotion_external_id { get; set; }
        public string relation { get; set; }
        public int? order { get; set; }
    }
    
    public class ConditionRelationPromotionCondition
    {
        public string external_id { get; set; }
        public string condition_relation_external_id { get; set; }
        public string promotion_condition_external_id { get; set; }
        public int? order { get; set; }
    }
    
    public class PromotionCondition
    {
        public string external_id { get; set; }
        public string name { get; set; }
    }
    
    public class PromotionConditionItem
    {
        public string external_id { get; set; }
        public string promotion_condition_external_id { get; set; }
        public string product_external_id { get; set; }
        public string product_category_external_id { get; set; }
        public decimal value { get; set; }
        public string value_type { get; set; }
        public decimal value_max { get; set; }
    }
    
    public class PromotionRewards
    {
        public string external_id { get; set; }
        public string promotion_external_id { get; set; }
        public string condition_relation_external_id { get; set; }
        public string product_external_id { get; set; }
        public string product_category_external_id { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public string value_type { get; set; }
        public decimal reward_value { get; set; }
        public string reward { get; set; }
    }
}