using muchik.market.domain.events;

namespace muchik.market.pay.application.events
{
    public class CreatePaymentEvent : Event
    {
        public string InvoiceId { get; set; }
        public decimal Total { get;set; }

        public CreatePaymentEvent(string invoiceId, decimal total)
        {
            InvoiceId = invoiceId;
            Total = total;
        }
    }
}
