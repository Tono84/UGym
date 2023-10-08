namespace BackEnd.Models
{
    public class AdminsModel
    {
        public int AdminId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }

    }
}