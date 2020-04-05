using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class BranchOffice
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Schedule { get; set; }
    }
}
