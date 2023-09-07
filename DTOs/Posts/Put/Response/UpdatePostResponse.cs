using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class UpdatePostResponse {
        /// <summary>
        /// Post ID.
        /// </summary>
        public int Id { get; set;}

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