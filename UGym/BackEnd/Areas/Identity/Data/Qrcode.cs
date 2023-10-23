namespace BackEnd.Areas.Identity.Data
{
    public class Qrcode
    {
        public Qrcode()
        {
            UGymUsers = new HashSet<UGymUser>();
        }

        public int QrcodeId { get; set; }
        public string LinkQr { get; set; } = null!;

        public virtual ICollection<UGymUser> UGymUsers { get; set; }
    }
}