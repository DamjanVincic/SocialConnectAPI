namespace SocialConnectAPI.DTOs.Comments {
    public class CreateCommentRequest {
        /// <summary>
        /// ID of the user that created the comment.
        /// </summary>
        public int UserId { get; set;}

        /// <summary>
        /// ID of the post that the comment is related to.
        /// </summary>
        public int PostId { get; set;}

        /// <summary>
        /// Comment content.
        /// </summary>
        public string Text { get; set;}
    }
}