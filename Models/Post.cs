using System.ComponentModel.DataAnnotations.Schema;
using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.DTOs.Comments;

namespace SocialConnectAPI.Models {
    /// <summary>
    /// Post model.
    /// </summary>
    public class Post {
        /// <summary>
        /// Model ID.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// ID of user that created the post.
        /// </summary>
        public int UserId { get; set;}
        public virtual User User { get; set;}

        /// <summary>
        /// Post content.
        /// </summary>
        public string Text { get; set;}

        /// <summary>
        /// Tags related to the post.
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Post status.
        /// </summary>
        public PostStatus Status { get; set; }

        /// <summary>
        /// Number of post likes.
        /// </summary>
        public int LikeCount { get; set; }
    }
}