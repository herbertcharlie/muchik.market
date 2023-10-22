using Microsoft.EntityFrameworkCore;
using muchik.market.pay.domain.entities;
using muchik.market.pay.domain.interfaces;
using muchik.market.pay.infrastructure.context;

namespace muchik.market.pay.infrastructure.repositories
{
    public class PayRepository : GenericRepository<Pay>, IPayRepository
    {
        public PayRepository(PayContext context) : base(context) { }

    }
}
