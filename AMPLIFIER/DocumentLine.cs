using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class DocumentLine
    {
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
    }
}
