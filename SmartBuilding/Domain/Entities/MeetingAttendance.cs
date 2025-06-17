using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MeetingAttendance
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        public bool IsPresent { get; set; }

        public string? Comment { get; set; }
    }


}
