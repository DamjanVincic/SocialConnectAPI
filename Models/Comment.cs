namespace SocialConnectAPI.Models {
    /// <summary>
    /// Comment model.
    /// </summary>
    public class Comment {
        public int Id { get; set;}
        public int UserId { get; set;}
        public virtual User User { get; set;}
        public virtual Post Post { get; set;}
        public int PostId { get; set;}
        public string Text { get; set;}
        public CommentStatus Status { get; set;}
    }
}