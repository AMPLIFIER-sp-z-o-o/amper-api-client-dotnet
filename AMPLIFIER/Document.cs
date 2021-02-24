using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class Document
    {
        public string customer { get; set; }
        public string number { get; set; }
        public string date { get; set; }
        public string due_date { get; set; }
        public string description { get; set; }
        public decimal value_net { get; set; }
        public decimal value_gross { get; set; }
        public string external_id { get; set; }
        public List<DocumentLine> document_lines { get; set; }
    }
}
