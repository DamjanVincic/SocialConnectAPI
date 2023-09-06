using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class UpdatePostResponse {
        public int Id { get; set;}
        public string Text { get; set;}
        public List<Tag> Tags { get; set; }
    }
}