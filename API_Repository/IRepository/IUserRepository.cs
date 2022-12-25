using API_Repository.Models;
using API_Repository.Models.DTO;

namespace API_Repository.IRepository
{
    public interface IUserRepository
    {
        bool existsUser(string username);
        Register Register(RegisterRequestDTO registerRequestDTO);
        LoginResponseDTO Login(LoginRequestDTO loginRequestDTO);
    }
}
