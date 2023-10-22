using MediatR;
using muchik.market.domain.bus;
using muchik.market.pay.application.commands;
using muchik.market.pay.application.events;

namespace muchik.market.pay.application.commandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public CreatePaymentCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new CreatePaymentEvent(request.InvoiceId, request.Total));
            return Task.FromResult(true);
        }
    }
}
