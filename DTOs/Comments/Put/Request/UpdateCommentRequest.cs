namespace SocialConnectAPI.DTOs.Comments {
    public class UpdateCommentRequest {
        /// <summary>
        /// Comment ID.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// Comment content.
        /// </summary>
        public string Text { get; set;}
    }
}