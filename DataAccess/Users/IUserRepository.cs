using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Users {
    public interface IUserRepository {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByEmail(string email);
        public User GetUserByNameSurname(string name, string surname);
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public void DeleteUserById(int id);
        public void DeleteUserByEmail(string email);
        public void MarkInactive(int userId);
        public void FollowUser(int userId, int userToFollowId);
        public void SaveChanges();
    }
}