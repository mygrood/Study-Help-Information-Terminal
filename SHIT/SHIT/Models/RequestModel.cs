using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    class RequestModel
    {
        public string Group { get; set; }
        public string Student { get;set; }
        public DateTime Birthday { get; set; }
        public int Quantity { get; set; }
        public string Where { get; set; }

        public string Military_Comissariat { get; set; }
        public bool Is_Active { get; set; }

    }
}
