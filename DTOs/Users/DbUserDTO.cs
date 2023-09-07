using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Users {
    /// <summary>
    /// User DTO to prevent circular references.
    /// </summary>
    public class DbUserDTO {
        /// <summary>
        /// User ID.
        /// </summary>
        public int Id { get; set; }

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
        /// User's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User status.
        /// </summary>
        public UserStatus Status { get; set; }
    }
}