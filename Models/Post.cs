using System.ComponentModel.DataAnnotations.Schema;

namespace SocialConnectAPI.Models {
    /// <summary>
    /// Post model.
    /// </summary>
    public class Post {
        public int Id { get; set;}
        public User User { get; set;}
        public int UserId { get; set;}
        public string Text { get; set;}
        // public List<Tag> Tags { get; set; }
        public List<string> Tags { get; set;}
        public PostStatus Status { get; set; }
        [NotMapped] // izbrisati
        public List<User> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}