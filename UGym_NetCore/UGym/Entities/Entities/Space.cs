using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Space
    {
        public Space()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int SpacesId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
