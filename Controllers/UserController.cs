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
            List<User>? users = userRepository.GetUsers();
            // pretvoriti listu usera, postova, komenatra u DTOove pre slanja
            if (users == null) {
                return NotFound();
            }
            return Ok(mapper.Map<List<GetUserResponse>>(users));
            // return Ok(users);
        }

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserResponse> GetUserById(int id) {
            User? user = userRepository.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(mapper.Map<GetUserResponse>(user));
        }

        /// <summary>
        /// Get a user by email.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserResponse> GetUserByEmail(string email) {
            User? user = userRepository.GetUserByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(mapper.Map<GetUserResponse>(user));
        }

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="user">User to be created.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CreateUserResponse> CreateUser(CreateUserRequest user) {
            try {
                var createdUser = userRepository.CreateUser(mapper.Map<User>(user));
                // userRepository.SaveChanges();
                return Created($"api/users/{createdUser.Id}", mapper.Map<CreateUserResponse>(createdUser));
            } catch {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update a user.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdateUserResponse> UpdateUser(UpdateUserRequest user) {
            try {
                User? userDB = userRepository.GetUserById(user.Id);
                if (userDB == null)
                    return NotFound();
                mapper.Map(user, userDB);
                userRepository.SaveChanges();
                return Ok(mapper.Map<UpdateUserResponse>(userDB));
            } catch {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserResponse> DeleteUserById(int id) {
            try {
                return Ok(mapper.Map<GetUserResponse>(userRepository.DeleteUserById(id)));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a user by email.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserResponse> DeleteUserByEmail(string email) {
            try {
                return Ok(mapper.Map<GetUserResponse>(userRepository.DeleteUserByEmail(email)));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Mark user as inactive.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("inactive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserResponse> MarkInactive(int id) {
            try {
                User user = userRepository.MarkInactive(id);
                return Ok(mapper.Map<GetUserResponse>(user));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Follow a user.
        /// </summary>
        /// <param name="userId">ID of the user that will follow</param>
        /// <param name="userToFollowId">ID of the user that to be followed</param>
        /// <returns></returns>
        [HttpPut]
        [Route("follow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult FollowUser(int userId, int userToFollowId) {
            try {
                userRepository.FollowUser(userId, userToFollowId);
                return Ok();
            } catch {
                return NotFound();
            }
        }
    }
}