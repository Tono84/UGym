using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime DateAttendance { get; set; }
        public TimeSpan TimeAttendance { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; } = null!;
    }
}
