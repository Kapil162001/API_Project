using API_Repository.DataContext;
using API_Repository.IRepository;
using API_Repository.Models;
using API_Repository.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dBContext;
        private string secretKey;
        public UserRepository(ApplicationDBContext dBContext, IConfiguration _configuration)
        {
            _dBContext = dBContext;
            secretKey = _configuration.GetValue<string>("ApiSetting:SecretKey");
        }

        public bool existsUser(string username)
        {
            var user = _dBContext.Registers.FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dBContext.Registers.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Result.UserName),
                    new Claim(ClaimTypes.Role, user.Result.Role),
                    new Claim(ClaimTypes.GivenName,user.Result.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user.Result,
            };
            return response;
        }

        public Register Register(RegisterRequestDTO registerRequestDTO)
        {
            var user = new Register()
            {
                UserName = registerRequestDTO.UserName,
                Password = registerRequestDTO.Password,
                Name = registerRequestDTO.Name,
                Role = registerRequestDTO.Role
            };
            _dBContext.Registers.Add(user);
            _dBContext.SaveChanges();
            user.Password = "";
            return user;
        }
    }
}
