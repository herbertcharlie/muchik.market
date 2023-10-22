namespace muchik.market.security.application.dto
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
