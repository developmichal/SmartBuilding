using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HouseCommittee
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }             
        public Building Building { get; set; }          

        public int ResidentId { get; set; }             
        public Resident Resident { get; set; }          

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
