using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class NutritionPlan
    {
        public int NutritionPlanId { get; set; }
        public string NutritionPlan1 { get; set; } = null!;
        public DateTime DateLoad { get; set; }
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
