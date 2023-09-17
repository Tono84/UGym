using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class EmergencyContact
    {
        public EmergencyContact()
        {
            Employees = new HashSet<Employee>();
            Members = new HashSet<Member>();
        }

        public int EmergencyContactId { get; set; }
        public string FullName { get; set; } = null!;
        public int MobileNumber { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
