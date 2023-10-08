namespace FrontEnd.Models
{
    public class MembersViewModel
    {
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
    }
}
