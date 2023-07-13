using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplifier
{
    public class CashDocumentOperation
    {
        public int id { get; set; }
        public Settlement settlement { get; set; }
        public string settlement_external_id { get; set; }
        public string amount { get; set; }
        public string settlement_number { get; set; }
        public string type { get; set; }
        public int document_header { get; set; }
    }

    public class CashDocument
    {
        public int id { get; set; }
        public List<CashDocumentOperation> cash_document_operations { get; set; }
        public string customer_external_id { get; set; }
        public Customer customer { get; set; }
        public string number { get; set; }
        public string created_at { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public object date_of_exportation { get; set; }
        public string amount { get; set; }
        public string user { get; set; }
        public string description { get; set; }
        public bool is_system_operation { get; set; }
        public string ordinal { get; set; }
        public int cash_drawer { get; set; }
        public string sales_rep_email { get; set; }
        public string sales_rep_first_name { get; set; }
        public string sales_rep_last_name { get; set; }
        public string sales_rep_phone { get; set; }
        public string sales_rep_identifier { get; set; }
    }
}
