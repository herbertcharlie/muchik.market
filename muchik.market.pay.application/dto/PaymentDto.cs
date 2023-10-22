namespace muchik.market.pay.application.dto
{
    public class PaymentDto
    {
        public string Id { get; set; } = null!;
        public string InvoiceId { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
