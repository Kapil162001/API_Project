using API_Repository.IRepository;
using API_Repository.Models;
using API_Repository.Models.DTO;

namespace API_Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool existsUser(string username)
        {
            return _userRepository.existsUser(username);
        }

        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {
            return _userRepository.Login(loginRequestDTO);
        }

        public Register Register(RegisterRequestDTO registerRequestDTO)
        {
            return _userRepository.Register(registerRequestDTO);
        }
    }
}
