using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Comments {
    /// <summary>
    /// Comment DTO to prevent circular references.
    /// </summary>
    public class DbCommentDTO {
        /// <summary>
        /// Comment ID.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// ID of the user that created the comment.
        /// </summary>
        public int UserId { get; set;}
        public virtual User User { get; set;}

        /// <summary>
        /// Comment content.
        /// </summary>
        public string Text { get; set;}

        /// <summary>
        /// Comment status.
        /// </summary>
        public CommentStatus Status { get; set;}
    }
}