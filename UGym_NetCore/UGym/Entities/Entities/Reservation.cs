using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime DateReservation { get; set; }
        public TimeSpan TimeReservationStart { get; set; }
        public TimeSpan TimeReservationEnd { get; set; }
        public int MemberId { get; set; }
        public int SpacesId { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Space Spaces { get; set; } = null!;
    }
}
