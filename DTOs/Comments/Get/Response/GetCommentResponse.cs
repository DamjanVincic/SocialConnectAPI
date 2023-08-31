using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Comments {
    public class GetCommentResponse {
        public int UserId { get; set;}
        public User User { get; set;}
        // public int PostId { get; set;}
        public Post Post { get; set;}
        public int PostId { get; set;}
        public string Text { get; set;}
    }
}