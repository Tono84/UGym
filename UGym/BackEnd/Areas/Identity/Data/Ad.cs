namespace BackEnd.Areas.Identity.Data
{
    public class Ad
    {
        public int AdId { get; set; }
        public string? Name { get; set; }
        public string? MediaLink { get; set; }
        public string UserId { get; set; } = null!;

        public virtual UGymUser User { get; set; } = null!;
    }
}