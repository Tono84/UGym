using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Template
    {
        public Template()
        {
            Routines = new HashSet<Routine>();
            TemplatesExercices = new HashSet<TemplatesExercice>();
        }

        public int TemplateId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Routine> Routines { get; set; }
        public virtual ICollection<TemplatesExercice> TemplatesExercices { get; set; }
    }
}
