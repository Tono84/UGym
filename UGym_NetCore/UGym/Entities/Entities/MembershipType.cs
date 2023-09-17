using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class MembershipType
    {
        public MembershipType()
        {
            MembersMembershipTypes = new HashSet<MembersMembershipType>();
        }

        public int MembershipTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;

        public virtual ICollection<MembersMembershipType> MembersMembershipTypes { get; set; }
    }
}
