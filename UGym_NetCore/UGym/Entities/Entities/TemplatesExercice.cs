using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TemplatesExercice
    {
        public int TemplateId { get; set; }
        public int ExerciceId { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Series { get; set; }
        public int? Reps { get; set; }

        public virtual Exercice Exercice { get; set; } = null!;
        public virtual Template Template { get; set; } = null!;
    }
}
