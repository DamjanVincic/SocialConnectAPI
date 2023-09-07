namespace SocialConnectAPI.Models {
    /// <summary>
    /// Comment model.
    /// </summary>
    public class Comment {
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
        /// ID of the post the comment is related to.
        /// </summary>
        public int PostId { get; set;}
        public virtual Post Post { get; set;}

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