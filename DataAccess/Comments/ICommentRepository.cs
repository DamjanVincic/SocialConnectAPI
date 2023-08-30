using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Comments {
    public interface ICommentRepository {
        public List<Comment> GetComments();
        public Comment GetCommentByUser(int userId);
        public Comment CreateComment(Comment comment);
        public Comment UpdateComment(Comment comment);
        public void DeleteComment(int id);
    }
}