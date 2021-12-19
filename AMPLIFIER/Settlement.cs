using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class Settlement{
        public string customer { get; set; }
        public string number { get; set; }
        public decimal value { get; set; }
        public decimal value_to_pay { get; set; }
        public string date { get; set; }
        public string due_date { get; set; }        
        public string external_id { get; set; }        
    }
}