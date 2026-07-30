using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplifier
{
    public class CoreDictionary
    {
        public string external_id { get; set; }
        public string value { get; set; }
        public string order { get; set; }
        public string type { get; set; }
    }

    public class CoreDictionaryCategory
    {
        public string external_id { get; set; }
        public string dictionary_external_id { get; set; }
        public string category_external_id { get; set; }

    }
}
