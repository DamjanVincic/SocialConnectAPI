using SocialConnectAPI.DataAccess.Users;
using SocialConnectAPI.Models;
using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.DTOs.Comments;
using AutoMapper;

namespace SocialConnectAPI.DataAccess.Posts {
    public class PostRepository : IPostRepository {
        private readonly DatabaseContext databaseContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public PostRepository (DatabaseContext databaseContext, IUserRepository userRepository, IMapper mapper) {
            this.databaseContext = databaseContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
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
            // return databaseContext.Posts.ToList().FindAll(p => p.Tags.Contains(tag));
            throw new NotImplementedException();
        }

        public Post CreatePost(Post post) {
            post.User = userRepository.GetUserById(post.UserId);
            if (post.User == null)
                throw new Exception("User not found.");
            // post.Likes = new List<User>();
            // post.Comments = new List<DbCommentDTO>();
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
            // baca gresku jer baza vraca null umesto liste
            
            return GetPosts().OrderByDescending(p => p.Likes.Count()).Take(10).ToList();
        }

        public void LikePost(int postId, int userId) {
            Post post = GetPostById(postId);
            // User user = new UserRepository(databaseContext).GetUserById(userId);
            User user = userRepository.GetUserById(userId);

            if (user == null || post == null)
                throw new Exception("Not found.");

            post.Likes.Add(mapper.Map<DbUserDTO>(user));
            // user.LikedPosts.Add(post);
            SaveChanges();
        }

        public bool SaveChanges() {
            return databaseContext.SaveChanges() > 0;
        }
    }
}