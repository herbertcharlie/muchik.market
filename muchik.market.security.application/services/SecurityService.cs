using AutoMapper;
using muchik.market.infrasctructure.crosscutting.Bcrypt;
using muchik.market.infrasctructure.crosscutting.Exceptions;
using muchik.market.infrasctructure.crosscutting.Jwt;
using muchik.market.security.application.dto;
using muchik.market.security.application.interfaces;
using muchik.market.security.domain.entities;
using muchik.market.security.domain.interfaces;

namespace muchik.market.security.application.services
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;
        private readonly IUserRepository _userRepository;
        

        public SecurityService(IMapper mapper, IJwtManager jwtManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _userRepository = userRepository;
        }

        public ICollection<UserDto> GetAllUsers()
        {
            var users = _userRepository.List();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public User GetUserByUsername(string username) {
            var currentUser = _userRepository.Find(s => s.Username.Equals(username)).FirstOrDefault();
            return currentUser;
        }

        public SignInResponseDto SignIn(SignInRequestDto signInRequestDto)
        {
            var currentUser = GetUserByUsername(signInRequestDto.Username);
            if (currentUser == null || !BCryptManager.Verify(signInRequestDto.Password, currentUser.Password)) throw new BusinessException("Username or password incorrect.");
            var signInResponseDto = _mapper.Map<SignInResponseDto>(currentUser);
            signInResponseDto.Token = _jwtManager.GenerateToken(signInResponseDto.Id, signInResponseDto.Username, signInResponseDto.CustomerId, signInResponseDto.Role);
            return signInResponseDto;
        }

        public void SignUp(CreateUserDto userDto)
        {
            var random = new Random();
            var value = random.Next(0, 2);
            if (value == 0)
            {
                throw new Exception("Random Timeout");
            }

            var currentUser = GetUserByUsername(userDto.Username);
            if (currentUser is not null)
            {
                throw new BusinessException("User alredy exists.");
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = BCryptManager.HashText(user.Password);
            _userRepository.Add(user);
            _userRepository.Save();      
        }
    }
}
