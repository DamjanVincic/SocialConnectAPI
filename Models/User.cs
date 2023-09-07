using System.ComponentModel.DataAnnotations;
using SocialConnectAPI.DTOs.Users;

namespace SocialConnectAPI.Models {
    /// <summary>
    /// User model.
    /// </summary>
    public class User {
        /// <summary>
        /// User ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        [MaxLength(25)]
        public string? Name { get; set; }

        /// <summary>
        /// Surname of the user.
        /// </summary>
        [MaxLength(50)]
        public string? Surname { get; set; }

        /// <summary>
        /// User's email.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        /// <summary>
        /// User's password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// User's status.
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// List of user's that the user is following.
        /// </summary>
        public virtual List<DbUserDTO> Following { get; set; } = new List<DbUserDTO>();

        /// <summary>
        /// List of users that are following the user.
        /// </summary>
        public virtual List<DbUserDTO> Followers { get; set; } = new List<DbUserDTO>();
    }
}