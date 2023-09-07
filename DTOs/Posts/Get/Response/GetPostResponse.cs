using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Posts {
    public class GetPostResponse {
        /// <summary>
        /// ID of the user that created the post.
        /// </summary>
        public int UserId { get; set;}
        public User User { get; set;}

        /// <summary>
        /// Post content.
        /// </summary>
        public string Text { get; set;}

        /// <summary>
        /// List of tags related to the post.
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Post status.
        /// </summary>
        public PostStatus Status { get; set; }
    }
}