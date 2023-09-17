using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class MembersCoachesClass
    {
        public int ClassesId { get; set; }
        public int CoachId { get; set; }
        public int MemberId { get; set; }
        public string? Description { get; set; }

        public virtual CoachesClass C { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
