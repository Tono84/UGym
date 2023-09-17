using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Class
    {
        public Class()
        {
            CoachesClasses = new HashSet<CoachesClass>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CoachesClass> CoachesClasses { get; set; }
    }
}
