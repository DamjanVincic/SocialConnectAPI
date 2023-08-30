using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Posts {
    public interface IPostRepository {
        public List<Post> GetPosts();
        public Post GetPostById(int id);
        public Post GetPostByUserId(int userId);
        public Post GetPostByTag(string tag);
        public Post CreatePost(Post post);
        public Post UpdatePost(Post post);
        public void DeletePost(int id);
        public void ArchivePost(int id);
        public List<Post> GetNumberOfPosts(int number);
        public void LikePost(int postId, int userId);
    }
}