using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Ads = new HashSet<Ad>();
            CoachesClasses = new HashSet<CoachesClass>();
            Members = new HashSet<Member>();
            NutritionPlans = new HashSet<NutritionPlan>();
            RepCardsEvaluations = new HashSet<RepCardsEvaluation>();
            RepCardsInbodies = new HashSet<RepCardsInbody>();
            RepCardsTherapies = new HashSet<RepCardsTherapy>();
            Reports = new HashSet<Report>();
            Routines = new HashSet<Routine>();
        }

        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int MobileNumber { get; set; }
        public int? EmergencyContactId { get; set; }
        public int RoleId { get; set; }

        public virtual EmergencyContact? EmergencyContact { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<CoachesClass> CoachesClasses { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<NutritionPlan> NutritionPlans { get; set; }
        public virtual ICollection<RepCardsEvaluation> RepCardsEvaluations { get; set; }
        public virtual ICollection<RepCardsInbody> RepCardsInbodies { get; set; }
        public virtual ICollection<RepCardsTherapy> RepCardsTherapies { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Routine> Routines { get; set; }
    }
}
