using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<HouseCommittee> HouseCommittees { get; set; }  // כל ועדי הבית בבניין

        public ICollection<Apartment> Apartments { get; set; }            // כל הדירות בבניין
    }
}
