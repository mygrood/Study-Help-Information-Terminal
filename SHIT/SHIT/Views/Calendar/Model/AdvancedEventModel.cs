using System;

namespace SHIT.Views.Calendar.Model
{
    
    public class AdvancedEventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime date { get; set; }
        public TimeSpan Starting { get; set; }
    }
}
