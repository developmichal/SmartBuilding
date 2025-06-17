using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateOnly ScheduledDate { get; set; }
        public DateOnly? DateChangeDeadline { get; set; }

        public string? Description { get; set; }
        public string? Summary { get; set; }
        public string? AudioFilePath { get; set; }

        public ICollection<MeetingAttendance> Attendances { get; set; }
    }

}
