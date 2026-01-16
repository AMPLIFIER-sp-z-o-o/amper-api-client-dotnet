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
        public DocumentProvider? document_provider { get; set; }
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
        public string payment_form_external_id { get; set; }
        public string is_external_document { get; set; }
        public string sales_rep_identifier { get; set; }
        public string sales_rep_first_name { get; set; }
        public string sales_rep_last_name { get; set; }
        public string sales_rep_email { get; set; }
        public string sales_rep_phone { get; set; }
        public object document_metadata { get; set; }
        public CoordsDetails coords_details { get; set; }
        public DeliveryAddress delivery_address { get; set; }
        public List<string> related_orders { get; set; }
    }

    public class DocumentLine
    {
        public int id { get; set; }
        public string external_id { get; set; }
        public string document { get; set; }
        public string product_symbol { get; set; }
        public string product_ean { get; set; }
        public string product_short_code { get; set; }
        public decimal? product_additional_fees_net { get; set; }
        public decimal? product_additional_fees_gross { get; set; }
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
        public decimal base_price { get; set; }
        public decimal percentage_discount { get; set; }
        public int source_document_line { get; set; }
        public object source_price_level_desc { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public string document_promotion { get; set; }
        public string promotion_condition { get; set; }
        public string promotion_condition_relation { get; set; }
        public int? source_price_level { get; set; }        
        public string price_level_external_id { get; set; }     
        public List<LineMetadata> line_metadata { get; set; }     
        public AppliedPromotion applied_promotion { get; set; }
        public bool is_promotion_reward { get; set; }
        public decimal? piggy_bank_budget { get; set; }
        public decimal? piggy_bank_budget_built { get; set; }
        public decimal? user_discount { get; set; }
        public int product { get; set; }
        public int? budget { get; set; }
        public int? source_target_goal { get; set; }
        public bool? export_rewards_to_a_separate_doc { get; set; }
        public string stock_fulfillment_options { get; set; }
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
        public int id { get; set; }
        public string customer_name { get; set; }
        public string customer_short_name { get; set; }
        public string sales_representatives { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public string username { get; set; }
        public bool virtual_visit { get; set; }
        public CoordsDetails coords_details { get; set; }
        public int customer { get; set; }
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
        public string internal_description { get; set; }
        public string external_identifier { get; set; }
        public bool is_required { get; set; }
    }

    public class DocumentProvider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
    }

    public class Coords
    {
        public string speed { get; set; }
        public string heading { get; set; }
        public string accuracy { get; set; }
        public string altitude { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string altitudeAccuracy { get; set; }
    }

    public class CoordsDetails
    {
        public Coords coords { get; set; }
        public string timestamp { get; set; }
    }

    
    public class LineMetadata
    {
        public int step { get; set; }
        public decimal? amount { get; set; }
        public decimal? discount { get; set; }
        public string description { get; set; }
        public int? relation_id { get; set; }
        public int? condition_id { get; set; }
        public int? price_level_id { get; set; }
    }

    public class DeliveryAddress
    {
        public string external_id { get; set; }
        public int id { get; set; }
        public object deleted { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public object street_continuation { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public string voivodeship { get; set; }
        public string company_name { get; set; }
        public int customer { get; set; }
    }

    public class DocumentDownloadRequest
    {
        public int id { get; set; }
        public int status { get; set; }
        public string keycloak_id { get; set; }
        public string user_name { get; set; }
        public string user_first_name { get; set; }
        public string user_last_name { get; set; }
        public string user_email { get; set; }
        public int document { get; set; }
        public string document_external_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? sent_at { get; set; }
    }
}
