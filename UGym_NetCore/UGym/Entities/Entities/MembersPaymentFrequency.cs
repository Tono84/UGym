using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class MembersPaymentFrequency
    {
        public int MemberId { get; set; }
        public int PaymentId { get; set; }
        public DateTime DatePayment { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual PaymentFrequency Payment { get; set; } = null!;
    }
}
