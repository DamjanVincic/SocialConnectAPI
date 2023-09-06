using System.ComponentModel.DataAnnotations.Schema;
using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.DTOs.Comments;

namespace SocialConnectAPI.Models {
    /// <summary>
    /// Post model.
    /// </summary>
    public class Post {
        public int Id { get; set;}
        public int UserId { get; set;}
        public virtual User User { get; set;}
        public string Text { get; set;}
        public virtual ICollection<Tag> Tags { get; set; }
        public PostStatus Status { get; set; }
        public int LikeCount { get; set; }
    }
}