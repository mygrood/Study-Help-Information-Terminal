using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Receipt
    {
        public string group { get; set; }
        public string student { get; set; }
        public string birthday { get; set; }
        public int quantity { get; set; }
        public string where { get; set; }
        public string military_commissariat { get; set; }
        public bool is_active { get; set; }
    }


}
