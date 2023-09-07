using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class UpdatePostRequest {
        /// <summary>
        /// Post ID.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// ID of the user that created the post.
        /// </summary>
        public int UserId { get; set;}

        /// <summary>
        /// Post content.
        /// </summary>
        public string Text { get; set;}

        /// <summary>
        /// List of tags related to the post.
        /// </summary>
        public List<Tag> Tags { get; set; }
    }
}