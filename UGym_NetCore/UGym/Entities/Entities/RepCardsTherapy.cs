using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class RepCardsTherapy
    {
        public int RepCardTherapyId { get; set; }
        public string LinkRepCardTherapy { get; set; } = null!;
        public DateTime DateLoad { get; set; }
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
