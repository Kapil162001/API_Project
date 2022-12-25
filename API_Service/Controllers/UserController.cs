using API_Repository.IRepository;
using API_Repository.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_Service.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = _userBusiness.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(loginResponse);
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register([FromBody] RegisterRequestDTO model)
        {
            bool ifUserNameUnique = _userBusiness.existsUser(model.UserName);
            if (!ifUserNameUnique)
            {
                return BadRequest("Username already exists");
            }
            var user = _userBusiness.Register(model);
            if (user == null)
            {
                return BadRequest("Error while registering");
            }
            return Ok("Register Successfully");
        }
    }
}
