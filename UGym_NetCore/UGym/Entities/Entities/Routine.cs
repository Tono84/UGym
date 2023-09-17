using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Routine
    {
        public Routine()
        {
            RoutinesExercices = new HashSet<RoutinesExercice>();
        }

        public int RoutineId { get; set; }
        public DateTime DateCreation { get; set; }
        public int EmployeeId { get; set; }
        public string? Comments { get; set; }
        public int? TemplateId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Template? Template { get; set; }
        public virtual ICollection<RoutinesExercice> RoutinesExercices { get; set; }
    }
}
