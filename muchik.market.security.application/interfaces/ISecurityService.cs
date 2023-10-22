using muchik.market.security.application.dto;

namespace muchik.market.security.application.interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
        ICollection<UserDto> GetAllUsers();
    }
}
