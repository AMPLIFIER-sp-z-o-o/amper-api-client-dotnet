using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class Document
    {
        public string external_id { get; set; }
        public int id { get; set; }
        public List<DocumentLine> document_lines { get; set; }
        public string customer_external_id { get; set; }
        public Customer customer { get; set; }
        public int? document_provider { get; set; }
        public Visit visit { get; set; }
        public DocumentType document_type { get; set; }
        public object stock_location { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public DateTime? due_date { get; set; }
        public string description { get; set; }
        public decimal value_net { get; set; }
        public decimal value_gross { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public string ordinal { get; set; }
        public int source_document { get; set; }
        public DateTime? print_date { get; set; }
        public DateTime? synchronization_date { get; set; }
        public DateTime? delivery_date { get; set; }
        public decimal percentage_discount { get; set; }
        public string username { get; set; }
        public string document_provider_short_name { get; set; }
        public string document_type_name { get; set; }
    }

    public class DocumentLine
    {
        public int id { get; set; }
        public string document { get; set; }
        public string product { get; set; }
        public string product_symbol { get; set; }
        public string product_ean { get; set; }
        public string product_name { get; set; }
        public int vat { get; set; }
        public string unit { get; set; }
        public decimal quantity { get; set; }
        public string unit_aggregate { get; set; }
        public decimal quantity_aggregate { get; set; }
        public decimal price_net { get; set; }
        public decimal price_gross { get; set; }
        public decimal value_net { get; set; }
        public decimal value_gross { get; set; }
        public string manufacturer { get; set; }
        public string make { get; set; }
        public string group { get; set; }
        public string product_external_id { get; set; }
        public int product_vat { get; set; }
        public string base_price { get; set; }
        public string percentage_discount { get; set; }
        public int source_document_line { get; set; }
        public object source_price_level_desc { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public string document_promotion { get; set; }
        public string promotion_condition { get; set; }
        public string promotion_condition_relation { get; set; }
        public int? source_price_level { get; set; }        
        public string price_level_external_id { get; set; }     
        public AppliedPromotion applied_promotion { get; set; }
    }

    public class DocumentType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string series { get; set; }
        public string template { get; set; }
        public bool annual { get; set; }
        public bool monthly { get; set; }
        public int current_number { get; set; }
        public string model_name { get; set; }
    }

    public class Visit
    {
        public DateTime date_start { get; set; }
        public object date_end { get; set; }
    }

    public class AppliedPromotion
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_code { get; set; }
        public object external_id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int priority { get; set; }
        public string description { get; set; }
    }


}
