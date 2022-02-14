﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifier
{
    public class OrderList
    {
        public string token { get; set; }
        public DateTime created { get; set; }
        public string status { get; set; }
        public string user_email { get; set; }
        public string total_gross { get; set; }
    }

    public class OrderLine
    {
        public int id { get; set; }
        public List<object> attributes { get; set; }
        public string product_external_id { get; set; }
        public string product_name { get; set; }
        public string product_sku { get; set; }
        public decimal quantity { get; set; }
        public string base_price_net { get; set; }
        public string discount { get; set; }
        public string unit_price_net { get; set; }
        public string unit_price_gross { get; set; }
        public string tax_rate { get; set; }
        public bool is_promotion_reward { get; set; }
        public int product { get; set; }
        public object promotion_condition { get; set; }
    }

    public class ShippingAddress
    {
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
        public int customer { get; set; }
    }

    public class Order
    {
        public string token { get; set; }
        public List<OrderLine> lines { get; set; }
        public string customer_external_id { get; set; }
        public ShippingAddress shipping_address { get; set; }
        public ShippingAddress billing_address { get; set; }
        public Customer customer { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string status { get; set; }
        public string user_email { get; set; }
        public string shipping_price_net { get; set; }
        public string shipping_price_gross { get; set; }
        public string products_total_net { get; set; }
        public string products_total_gross { get; set; }
        public string total_net { get; set; }
        public string total_gross { get; set; }
        public object paid { get; set; }
        public object discount_amount { get; set; }
        public string customer_note { get; set; }
        public int shipment_type { get; set; }
    }
}