using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Ad
    {
        public int AdId { get; set; }
        public string? Name { get; set; }
        public string? MediaLink { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
