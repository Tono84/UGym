using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Qrcode
    {
        public Qrcode()
        {
            Members = new HashSet<Member>();
        }

        public int QrcodeId { get; set; }
        public string LinkQr { get; set; } = null!;

        public virtual ICollection<Member> Members { get; set; }
    }
}
