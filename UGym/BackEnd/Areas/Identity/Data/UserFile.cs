namespace BackEnd.Areas.Identity.Data
{
    public class UserFile
    {
        public UserFile()
        {
            UGymUsers = new HashSet<UGymUser>();
        }

        public int UserFileId { get; set; }
        public string CirguriesType { get; set; } = null!;
        public int QuantCirguries { get; set; }
        public string? DetailCirguries { get; set; }
        public string? TypeMeds { get; set; }
        public int? QuantMeds { get; set; }
        public string? AlergyMeds { get; set; }
        public string? HeartDis { get; set; }
        public string? ChestPain { get; set; }
        public int? TimeSitting { get; set; }
        public int? SleepCycle { get; set; }
        public int? LastMonthStress { get; set; }
        public int? TrainMotivation { get; set; }
        public string? FatDifLoss { get; set; }
        public string? LmonthEnergy { get; set; }
        public int? StepsDay { get; set; }
        public string? ThreeMonthEx { get; set; }
        public string? AttendanceMotivation { get; set; }
        public string? AutoReg { get; set; }
        public int? Focus { get; set; }
        public int? Nutrition { get; set; }
        public string? StressNutrition { get; set; }

        public virtual ICollection<UGymUser> UGymUsers { get; set; }
    }
}