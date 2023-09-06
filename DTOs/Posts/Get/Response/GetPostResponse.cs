using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class GetPostResponse {
        public User User { get; set;}
        public int UserId { get; set;}
        public string Text { get; set;}
        public List<Tag> Tags { get; set; }
        public PostStatus Status { get; set; }
    }
}