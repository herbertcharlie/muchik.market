using muchik.market.security.domain.entities;
using muchik.market.security.domain.interfaces;
using muchik.market.security.infrastructure.context;

namespace muchik.market.security.infrastructure.repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
