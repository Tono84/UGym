namespace BackEnd.Areas.Identity.Data
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string ReportType { get; set; } = null!;
        public string? Description { get; set; }
        public string? ReportDate { get; set; }
        public string UserId { get; set; } = null!;

        public virtual UGymUser User { get; set; } = null!;
    }
}