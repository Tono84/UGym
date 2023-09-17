using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string ReportType { get; set; } = null!;
        public string? Description { get; set; }
        public string? ReportDate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
