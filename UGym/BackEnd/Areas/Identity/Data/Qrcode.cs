using System;
using System.Collections.Generic;

namespace BackEnd.Areas.Identity.Data
{
    public class Qrcode
    {
        public Qrcode()
        {
            CFTestUsers = new HashSet<UGymUser>();
        }

        public int QrcodeId { get; set; }
        public string LinkQr { get; set; } = null!;

        public virtual ICollection<UGymUser> CFTestUsers { get; set; }
    }
}
