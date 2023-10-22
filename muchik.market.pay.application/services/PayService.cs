using AutoMapper;
using muchik.market.domain.bus;
using muchik.market.pay.application.commands;
using muchik.market.pay.application.dto;
using muchik.market.pay.application.dto.Creates;
using muchik.market.pay.application.interfaces;
using muchik.market.pay.domain.entities;
using muchik.market.pay.domain.interfaces;

namespace muchik.market.pay.application.services
{
    public class PayService : IPayService
    {
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly IPayRepository _payRepository;

        public PayService(IMapper mapper, IEventBus eventBus, IPayRepository payRepository)
        {
            _mapper = mapper;
            _eventBus = eventBus;
            _payRepository = payRepository;
        }


        public async Task<bool> CreatePayment(CreatePaymentDto paymentDto) 
        {
            var pay = _mapper.Map<Pay>(paymentDto);
            _payRepository.Add(pay);

            var successRegister = _payRepository.Save();

            if (successRegister)
            {
                await _eventBus.SendCommand(new CreatePaymentCommand(pay.InvoiceId, pay.Total));
            }

            return successRegister;
        }
    }
}
