using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.Models;

namespace DTOs.Users {
    public class GetUserResponse {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public List<DbUserDTO> Following { get; set; }
        public List<DbUserDTO> Followers { get; set; }
    }
}