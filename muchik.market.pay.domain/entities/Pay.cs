using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.pay.domain.entities
{
    public partial class Pay
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string InvoiceId { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
