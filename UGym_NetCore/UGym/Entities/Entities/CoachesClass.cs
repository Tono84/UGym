using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class CoachesClass
    {
        public CoachesClass()
        {
            MembersCoachesClasses = new HashSet<MembersCoachesClass>();
        }

        public int ClassId { get; set; }
        public int CoachId { get; set; }
        public int Slots { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Employee Coach { get; set; } = null!;
        public virtual ICollection<MembersCoachesClass> MembersCoachesClasses { get; set; }
    }
}
