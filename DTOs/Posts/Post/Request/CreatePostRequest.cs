using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class CreatePostRequest {
        public int UserId { get; set;}
        public string Text { get; set;}
        // public List<Tag> Tags { get; set; }
        public List<string> Tags { get; set;}
    }
}