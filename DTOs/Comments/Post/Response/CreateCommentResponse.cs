using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Comments {
    public class CreateCommentResponse {
        /// <summary>
        /// Comment ID.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// ID of the user that created the comment.
        /// </summary>
        public int UserId { get; set;}
        public User User { get; set;}

        /// <summary>
        /// ID of the post that the comment is related to.
        /// </summary>
        public int PostId { get; set;}
        public Post Post { get; set;}

        /// <summary>
        /// Comment content.
        /// </summary>
        public string Text { get; set;}
    }
}