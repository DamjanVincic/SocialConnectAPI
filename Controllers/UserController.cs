using AutoMapper;
using DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using SocialConnectAPI.DataAccess.Users;
using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Controllers {
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase {
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserController (IUserRepository userRepository, IMapper mapper) {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetUserResponse>> GetUsers() {
            List<User> users = userRepository.GetUsers();
            // pretvoriti listu usera, postova, komenatra u DTOove pre slanja
            if (users == null) {
                return NotFound();
            }
            return Ok(mapper.Map<List<GetUserResponse>>(users));
        }

        // GetUserById, GetUserByEmail

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="user">User to be created.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CreateUserResponse> CreateUser([FromBody] CreateUserRequest user) {
            try {
                var createdUser = userRepository.CreateUser(mapper.Map<User>(user));
                // userRepository.SaveChanges();
                return Created($"api/users/{createdUser.Id}", mapper.Map<CreateUserResponse>(createdUser));
            } catch {
                return StatusCode(500);
            }

        }
    }
}