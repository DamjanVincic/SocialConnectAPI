using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Comments {
    public interface ICommentRepository {
        public List<Comment> GetComments();
        public Comment? GetCommentById(int id);
        public List<Comment> GetCommentsByUserId(int userId);
        public Comment CreateComment(Comment comment);
        public Comment UpdateComment(Comment comment);
        public Comment DeleteComment(int id);
        public bool SaveChanges();
    }
}