namespace SocialConnectAPI.DTOs.Posts {
    public class UpdatePostRequest {
        public int Id { get; set;}
        public int UserId { get; set;}
        public string Text { get; set;}
        // public List<Tag> Tags { get; set; }
        public List<string> Tags { get; set;}
    }
}