using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class Account
    {
        public string name { get; set; }
        public string short_name { get; set; }
        public string external_id { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string voivodeship { get; set; }
        public string tax_id { get; set; }
        public List<Customer> customers { get; set; }
    }
    public class Customer
    {
        public string external_id { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string primary_email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public string tax_id { get; set; }
        public string comments { get; set; }
        public string price_level_external_id { get; set; }
        public string payment_form_external_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public decimal trade_credit_limit { get; set; }
        public decimal overdue_limit { get; set; }
        public decimal discount { get; set; }
        public string currency_code { get; set; }
        public int id { get; set; }
        public int overdue_settlements { get; set; }
        public string currency_format { get; set; }
        public string ftp_host { get; set; }
        public string ftp_port { get; set; }
        public string ftp_user { get; set; }
        public string ftp_pass { get; set; }
        public bool ftp_secure { get; set; }
        public string type { get; set; }
        public DateTime added_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? first_login_at { get; set; }
        public bool is_free_shipping { get; set; }
        public int? account { get; set; }
        public string default_address { get; set; }
        public string currency { get; set; }
        public string updatable_fields = "";
        public string stock_location_external_id = "";
        public DateTime? concession_a_valid_until { get; set; }
        public DateTime? concession_b_valid_until { get; set; }
        public DateTime? concession_c_valid_until { get; set; }
    }

    public class CustomerProductLogisticMinimum
    {
        public string external_id { get; set; }
        public string product_external_id { get; set; }
        public string customer_external_id { get; set; }
        public decimal logistic_minimum { get; set; }
    }

    public class Address
    {
        public string name { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public string street_continuation { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string voivodeship { get; set; }
        public string external_id { get; set; }
        public string customer_external_id { get; set; }
        public string updatable_fields = "";
    }

    public class CustomerCategory
    {
        public string external_id { get; set; }
        public string parent_external_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string seo_tags { get; set; }
        public int order { get; set; }
        public string updatable_fields = "";
    }

    public class CustomerCategoryRelation
    {
        public string external_id { get; set; }
        public string category_external_id { get; set; }
        public string customer_external_id { get; set; }
    }

    public class CustomerSalesRepresentative
    {
        public string external_id { get; set; }
        public string sales_representative_identifier { get; set; }
        public string customer_category_external_id { get; set; }
        public string customer_external_id { get; set; }
    }

    public class PaymentForm
    {
        public string external_id { get; set; }
        public string name { get; set; }
        public bool is_cache { get; set; }
        public int default_payment_date_in_days { get; set; }
    }
}