namespace BackEnd.Areas.Identity.Data
{
    public partial class EmergencyContact
    {
        public EmergencyContact()
        {
            UGymUsers = new HashSet<UGymUser>();
        }

        public int EmergencyContactId { get; set; }
        public string FullName { get; set; } = null!;
        public int MobileNumber { get; set; }

        public virtual ICollection<UGymUser> UGymUsers { get; set; }
    }
}