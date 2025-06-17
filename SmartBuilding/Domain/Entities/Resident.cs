using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Resident
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }         
        public Apartment Apartment { get; set; }    

        public ICollection<Repair> Repairs { get; set; }     
        public ICollection<MeetingAttendance> MeetingAttendances { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

}
