using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class RepCardsInbody
    {
        public int InformeInbodyId { get; set; }
        public string LinkRepCardeInbody { get; set; } = null!;
        public DateTime DateLoad { get; set; }
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
