using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class MembersMembershipType
    {
        public int MemberId { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateExp { get; set; }
        public string? Status { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual MembershipType MembershipType { get; set; } = null!;
    }
}
