using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Member
    {
        public Member()
        {
            Attendances = new HashSet<Attendance>();
            MembersCoachesClasses = new HashSet<MembersCoachesClass>();
            MembersMembershipTypes = new HashSet<MembersMembershipType>();
            MembersPaymentFrequencies = new HashSet<MembersPaymentFrequency>();
            MembersRoutinesExercices = new HashSet<MembersRoutinesExercice>();
            NutritionPlans = new HashSet<NutritionPlan>();
            RepCardsEvaluations = new HashSet<RepCardsEvaluation>();
            RepCardsInbodies = new HashSet<RepCardsInbody>();
            RepCardsTherapies = new HashSet<RepCardsTherapy>();
            Reservations = new HashSet<Reservation>();
        }

        public int MemberId { get; set; }
        public int MemberNumb { get; set; }
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Gender { get; set; }
        public int Cedula { get; set; }
        public DateTime Birthday { get; set; }
        public string? Ocupation { get; set; }
        public string? KnowGym { get; set; }
        public string? Motivation { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public int EmergencyContactId { get; set; }
        public int? MembFileId { get; set; }
        public int? QrcodeId { get; set; }
        public int? EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual EmergencyContact EmergencyContact { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        public virtual MembFile? MembFile { get; set; }
        public virtual Qrcode? Qrcode { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<MembersCoachesClass> MembersCoachesClasses { get; set; }
        public virtual ICollection<MembersMembershipType> MembersMembershipTypes { get; set; }
        public virtual ICollection<MembersPaymentFrequency> MembersPaymentFrequencies { get; set; }
        public virtual ICollection<MembersRoutinesExercice> MembersRoutinesExercices { get; set; }
        public virtual ICollection<NutritionPlan> NutritionPlans { get; set; }
        public virtual ICollection<RepCardsEvaluation> RepCardsEvaluations { get; set; }
        public virtual ICollection<RepCardsInbody> RepCardsInbodies { get; set; }
        public virtual ICollection<RepCardsTherapy> RepCardsTherapies { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
