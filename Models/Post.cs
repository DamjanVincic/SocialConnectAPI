namespace SocialConnectAPI.Models {
    /// <summary>
    /// Post model.
    /// </summary>
    public class Post {
        public int Id { get; set;}
        // public int UserId { get; set;}
        public User User { get; set;}
        public string Text { get; set;}
        public List<string> Tags { get; set; }
        public PostStatus Status { get; set; }
        public List<User> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}