namespace muchik.market.pay.application.commands
{
    public class CreatePaymentCommand : PaymentCommand
    {
        public CreatePaymentCommand(string invoiceId, decimal total) 
        {
            InvoiceId = invoiceId;
            Total = total;
        }
    }
}
