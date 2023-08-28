namespace WeConnect.Models
{
    public class Posts
    {
        public int ID { get; set; }
        public int Likes { get; set; }
        //user_id
        //thread_id
        public string? Content { get; set; }
        public int Dislikes { get; set; }
        public int Timestamp { get; set; }
        public string? ImageURL { get; set; }
    }
}
