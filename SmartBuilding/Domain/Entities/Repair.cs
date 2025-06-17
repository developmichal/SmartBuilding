using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Repair
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        public int RepairTypeId { get; set; }
        public RepairType RepairType { get; set; }

        public DateOnly ReportDate { get; set; }

        public DateOnly? StatusChangeDate { get; set; }

        public int RepairStatusId { get; set; }
        public RepairStatus RepairStatus { get; set; }

        public string? Comments { get; set; }
    }

}
