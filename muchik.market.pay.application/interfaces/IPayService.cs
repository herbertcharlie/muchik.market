using muchik.market.pay.application.dto;
using muchik.market.pay.application.dto.Creates;

namespace muchik.market.pay.application.interfaces
{
    public interface IPayService
    {
        Task<bool> CreatePayment(CreatePaymentDto paymentDto);
    }
}
