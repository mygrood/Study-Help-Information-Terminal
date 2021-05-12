using System;
using System.Collections.Generic;
using System.Text;

namespace SHIT.Models
{
    class LessonModel
    {
        int Id { get; set; }
        int WeekDay { get; set; }
        TimeSpan StartTime { get; set; }
        int Duration { get; set; }
        int GroupId { get; set; }
        int SubjectId { get; set; }
        int TeacherId { get; set; }
        int ClassroomId { get; set; }

    }
}
