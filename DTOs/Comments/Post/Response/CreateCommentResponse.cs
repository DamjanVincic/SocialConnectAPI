using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Comments {
    public class CreateCommentResponse {
        public int Id { get; set;}
        public int UserId { get; set;}
        public User User { get; set;}
        public Post Post { get; set;}
        public int PostId { get; set;}
        public string Text { get; set;}
    }
}