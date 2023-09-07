using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.Models;

namespace DTOs.Users {
    public class GetUserResponse {
        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's status.
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// List of users that the user is following.
        /// </summary>
        public List<DbUserDTO> Following { get; set; }

        /// <summary>
        /// List of users that are following the user.
        /// </summary>
        public List<DbUserDTO> Followers { get; set; }
    }
}