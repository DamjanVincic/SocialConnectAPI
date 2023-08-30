using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess.Users {
    public class UserRepository : IUserRepository {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }


        public List<User>? GetUsers() {
            return databaseContext.Users.ToList();
        }

        public User? GetUserById(int id) {
            return databaseContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetUserByEmail(string email) {
            return databaseContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserByNameSurname(string name, string surname) {
            return databaseContext.Users.FirstOrDefault(u => u.Name == name && u.Surname == surname);
        }

        public User CreateUser(User user) {
            var createdUser = databaseContext.Users.Add(user);
            return createdUser.Entity;
        }

        public User UpdateUser(User user) {
            throw new NotImplementedException();
        }

        public User DeleteUserById(int id) {
            User user = GetUserById(id);
            if (user == null)
                throw new Exception("User not found");
            var deletedUser = databaseContext.Users.Remove(user);
            return deletedUser.Entity;
        }

        public User DeleteUserByEmail(string email) {
            User user = GetUserByEmail(email);
            if (user == null)
                throw new Exception("User not found");
            var deletedUser = databaseContext.Users.Remove(user);
            return deletedUser.Entity;
        }

        public void MarkInactive(int userId) {
            User user = GetUserById(userId);
            if (user == null)
                throw new Exception("User not found");
            user.Status = UserStatus.Inactive;
        }

        public void FollowUser(int userId, int userToFollowId) {
            User user = GetUserById(userId);
            User userToFollow = GetUserById(userToFollowId);
            if (user == null || userToFollow == null)
                throw new Exception("User not found");
            user.Following.Add(userToFollow);
            userToFollow.Followers.Add(user);
        }

        public bool SaveChanges() {
            return databaseContext.SaveChanges() > 0;
        }
    }
}