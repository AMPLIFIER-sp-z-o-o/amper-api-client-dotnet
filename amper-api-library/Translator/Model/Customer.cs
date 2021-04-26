using System.Collections.Generic;

namespace Amplifier
{
    public class Account
    {
        public string name { get; set; }
        public string short_name { get; set; }
        public string external_id { get; set; }
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
        public string login { get; set; }
        public string password { get; set; }
        public string template { get; set; }
        public bool mail_export  { get; set; }
        public bool ftp_export  { get; set; }
        public bool doc_export  { get; set; }
        public bool offer_export  { get; set; }
        public decimal trade_credit_limit { get; set; }
        public decimal overdue_limit { get; set; }
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
    }

}