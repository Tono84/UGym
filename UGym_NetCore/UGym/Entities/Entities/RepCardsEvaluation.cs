using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class RepCardsEvaluation
    {
        public int RepCardEvaluationId { get; set; }
        public string LinkRepCardEvaluation { get; set; } = null!;
        public DateTime DateLoad { get; set; }
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
