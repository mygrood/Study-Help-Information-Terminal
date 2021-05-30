using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SpGroup
    {
        public string name { get; set; }
        public List<Group> groups { get; set; }
    }

}
