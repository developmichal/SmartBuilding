﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepairStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Repair> Repairs { get; set; }
    }
}
