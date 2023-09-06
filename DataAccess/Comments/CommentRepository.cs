using AutoMapper;
using SocialConnectAPI.DataAccess.Posts;
using SocialConnectAPI.DataAccess.Users;
using SocialConnectAPI.DTOs.Comments;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Comments {
    public class CommentRepository : ICommentRepository {
        private readonly DatabaseContext databaseContext;
        private IUserRepository userRepository;
        private IPostRepository postRepository;

        public CommentRepository (DatabaseContext databaseContext, IUserRepository userRepository, IPostRepository postRepository) {
            this.databaseContext = databaseContext;
            this.userRepository = userRepository;
            this.postRepository = postRepository;
        }

        public List<Comment> GetComments() {
            return databaseContext.Comments.ToList().FindAll(c => c.Status != CommentStatus.Deleted);
        }

        public Comment? GetCommentById(int id) {
            return databaseContext.Comments.FirstOrDefault(c => c.Id == id && c.Status != CommentStatus.Deleted);
        }

        public Comment? GetCommentByUserId(int id) {
            return databaseContext.Comments.FirstOrDefault(c => c.User.Id == id && c.Status != CommentStatus.Deleted);
        }

        public Comment CreateComment(Comment comment) {
            comment.User = userRepository.GetUserById(comment.UserId);
            comment.Post = postRepository.GetPostById(comment.PostId);
            if (comment.User == null || comment.Post == null)
                throw new Exception("User or post not found.");
            databaseContext.Comments.Add(comment);
            SaveChanges();
            return comment;
        }

        public Comment UpdateComment(Comment comment) {
            throw new NotImplementedException();
        }

        public Comment DeleteComment(int id) {
            Comment? comment = GetCommentById(id);
            if (comment == null)
                throw new Exception("Comment not found.");
            var deletedComment = databaseContext.Comments.Remove(comment);
            SaveChanges();
            return deletedComment.Entity;
        }

        public bool SaveChanges() {
            return databaseContext.SaveChanges() > 0;
        }
    }
}