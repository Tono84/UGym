using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
