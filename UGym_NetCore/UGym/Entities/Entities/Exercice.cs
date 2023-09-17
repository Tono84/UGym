using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Exercice
    {
        public Exercice()
        {
            RoutinesExercices = new HashSet<RoutinesExercice>();
            TemplatesExercices = new HashSet<TemplatesExercice>();
        }

        public int ExerciceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Video { get; set; }

        public virtual ICollection<RoutinesExercice> RoutinesExercices { get; set; }
        public virtual ICollection<TemplatesExercice> TemplatesExercices { get; set; }
    }
}
