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
        public virtual List<User> Following { get; set; } = new List<User>();
        public virtual List<User> Followers { get; set; } = new List<User>();
        // public List<Post> LikedPosts { get; set; }
    }
}