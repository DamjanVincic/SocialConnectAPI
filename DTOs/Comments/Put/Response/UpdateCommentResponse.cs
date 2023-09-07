namespace SocialConnectAPI.DTOs.Comments {
    public class UpdateCommentResponse {
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