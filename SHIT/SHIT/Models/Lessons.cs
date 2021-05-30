using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    // Lesson myDeserializedClass = JsonConvert.DeserializeObject<Lesson>(myJsonResponse); 
    public class Lesson
    {
        public int id { get; set; }
        public int week_day { get; set; }
        public string start_time { get; set; }
        public int duration { get; set; }
        public string group { get; set; }
        public bool? is_top { get; set; }
        public string subject { get; set; }
        public string teacher { get; set; }
        public string classroom { get; set; }
    }

    public class DayLesson
    {
        public int id { get; set; }
        public int week_day { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public int duration { get; set; }
        public string group { get; set; }
        public bool? is_top { get; set; }
        public string subject { get; set; }
        public string teacher { get; set; }
        public string classroom { get; set; }
    }
}
