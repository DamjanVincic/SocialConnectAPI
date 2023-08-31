namespace SocialConnectAPI.Models {
    /// <summary>
    /// User model.
    /// </summary>
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public List<User> Following { get; set; }
        public List<User> Followers { get; set; }
        // public List<Post> LikedPosts { get; set; }
    }
}