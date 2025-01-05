using ExpenseApp.Models.Entity;
using ExpenseApp.Repository;
using ExpenseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IPasswordHasherServiceRepository _passwordHasherServiceRepository;

        public UserDetailsController(IUserDetailsRepository repository, IPasswordHasherServiceRepository passwordHasherServiceRepository)
        {
            _userDetailsRepository = repository;
            _passwordHasherServiceRepository = passwordHasherServiceRepository;
        }

        [HttpGet("GetUserDetails")]
        public ActionResult<UserDetails> GetUserDetails([FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var userDetails = _userDetailsRepository.GetUserDetails(userId);

            if (userDetails == null)
            {
                return NotFound($"User details not found for User ID: {userId}");
            }

            return Ok(userDetails);
        }

        [HttpPost("addUser")]
        public ActionResult<string> AddUserDetails([FromBody] UserDetails userDetails)
        {
            if (userDetails == null)
            {
                return BadRequest("User details cannot be null.");
            }
            else
            {
                var user = _passwordHasherServiceRepository.SavePassword(userDetails, userDetails.Password);
                return _userDetailsRepository.AddUserDetails(user);
            }
        }

        [HttpPut("updateUser")]
        public ActionResult<UserDetails> UpdateUser([FromBody] UserDetails userDetails)
        {
            var updatedUserDetails = _userDetailsRepository.UpdateUserDetails(userDetails);
            if (updatedUserDetails == null)
            {
                return NotFound($"User details not found for User ID: {userDetails.UserId}");
            }
            return Accepted(updatedUserDetails);
        }
        [HttpPost("login")]
        public ActionResult<UserDetails> Login([FromBody] Login login)
        {
            var user = _passwordHasherServiceRepository.GetUserByIdentifier(login.UserIdentifier);
            if (user == null)
            {
                return NotFound($"User with '{login.UserIdentifier}' not found.");
            }
            if (!_passwordHasherServiceRepository.ValidatePassword(user, login.Password))
            {
                return Unauthorized("Invalid password.");
            }
            return Ok(user);
        }

    }
}
