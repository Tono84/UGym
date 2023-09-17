using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Role
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
            Employees = new HashSet<Employee>();
            Members = new HashSet<Member>();
        }

        public int RolesId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
