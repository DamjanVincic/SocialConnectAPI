using SocialConnectAPI.DataAccess.Users;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Posts {
    public class PostRepository : IPostRepository {
        private readonly DatabaseContext databaseContext;

        public PostRepository (DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public List<Post> GetPosts() {
            return databaseContext.Posts.ToList().FindAll(p => p.Status != PostStatus.Archived && p.Status != PostStatus.Deleted);
        }

        public Post? GetPostById(int id) {
            return databaseContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public Post? GetPostByUserId(int userId) {
            return databaseContext.Posts.FirstOrDefault(p => p.UserId == userId);
        }

        public List<Post> GetPostsByTag(string tag) {
            return databaseContext.Posts.ToList().FindAll(p => p.Tags.Contains(tag));
        }

        public Post CreatePost(Post post) {
            post.Tags = new List<string>();
            // post.Likes = new List<User>();
            post.Comments = new List<Comment>();
            var createdPost = databaseContext.Posts.Add(post);
            SaveChanges();
            return createdPost.Entity;
        }

        public Post UpdatePost(Post post) {
            throw new NotImplementedException();
        }

        public Post DeletePost(int id) {
            Post post = GetPostById(id);
            if (post == null)
                throw new Exception("Post not found.");
            var deletedPost = databaseContext.Posts.Remove(post);
            SaveChanges();
            return deletedPost.Entity;
        }

        public Post ArchivePost(int id) {
            Post post = GetPostById(id);
            if (post == null)
                throw new Exception("Post not found.");
            post.Status = PostStatus.Archived;
            SaveChanges();
            return post;
        }

        public List<Post> GetNumberOfPosts(int number) {
            return GetPosts().OrderByDescending(p => p.Likes.Count()).Take(10).ToList();
        }

        public void LikePost(int postId, int userId) {
            Post post = GetPostById(postId);
            User user = new UserRepository(databaseContext).GetUserById(userId);

            if (user == null || post == null)
                throw new Exception("Not found.");

            post.Likes.Add(user);
            // user.LikedPosts.Add(post);
            SaveChanges();
        }

        public bool SaveChanges() {
            return databaseContext.SaveChanges() > 0;
        }
    }
}