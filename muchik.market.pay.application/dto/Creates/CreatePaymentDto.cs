namespace muchik.market.pay.application.dto.Creates
{
    public class CreatePaymentDto
    {
        public string InvoiceId { get; set; } = null!;
        public decimal Total { get; set; }


    }
}