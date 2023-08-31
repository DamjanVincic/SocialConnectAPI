using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Users {
    public class UpdateUserRequest {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public List<Post> LikedPosts { get; set; }
    }
}