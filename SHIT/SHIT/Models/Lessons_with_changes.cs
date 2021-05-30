using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    //api/lessons_with_changes/{group_id}/{date}/
    public class Change
    {
        public int id { get; set; }
        public string date { get; set; }
        public int lesson { get; set; }
        public object group { get; set; }
        public string start_time { get; set; }
        public int duration { get; set; }
        public string subject { get; set; }
        public string teacher { get; set; }
        public string classroom { get; set; }
    }

    public class RootChanges
    {
        public List<Lesson> lessons { get; set; }
        public List<Change> changes { get; set; }
    }
}
