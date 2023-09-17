using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class MembersRoutinesExercice
    {
        public int MemberId { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public string Status { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;
        public virtual RoutinesExercice RoutinesExercice { get; set; } = null!;
    }
}
