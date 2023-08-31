namespace SocialConnectAPI.DTOs.Comments {
    public class CreateCommentRequest {
        public int UserId { get; set;}
        // public int PostId { get; set;}
        public int PostId { get; set;}
        public string Text { get; set;}
    }
}