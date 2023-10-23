namespace BackEnd.Areas.Identity.Data
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime DateAttendance { get; set; }
        public TimeSpan TimeAttendance { get; set; }
        public string UserId { get; set; } = null!;

        public virtual UGymUser User { get; set; } = null!;
    }
}