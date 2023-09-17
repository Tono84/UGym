using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class PaymentFrequency
    {
        public PaymentFrequency()
        {
            MembersPaymentFrequencies = new HashSet<MembersPaymentFrequency>();
        }

        public int PaymentId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Amount { get; set; }

        public virtual ICollection<MembersPaymentFrequency> MembersPaymentFrequencies { get; set; }
    }
}
