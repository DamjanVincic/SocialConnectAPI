using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Comments {
    public class DbCommentDTO {
        public int Id { get; set;}
        public int UserId { get; set;}
        public virtual User User { get; set;}
        public string Text { get; set;}
        public CommentStatus Status { get; set;}
    }
}