using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class RoutinesExercice
    {
        public RoutinesExercice()
        {
            MembersRoutinesExercices = new HashSet<MembersRoutinesExercice>();
        }

        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Series { get; set; }
        public int? Reps { get; set; }

        public virtual Exercice Exercise { get; set; } = null!;
        public virtual Routine Routine { get; set; } = null!;
        public virtual ICollection<MembersRoutinesExercice> MembersRoutinesExercices { get; set; }
    }
}
