using muchik.market.domain.commands;

namespace muchik.market.pay.application.commands
{
    public class PaymentCommand : Command
    {
        public string InvoiceId { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
