namespace BackEnd.Models
{
    public class EmployeesModel
    {
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
    }
}