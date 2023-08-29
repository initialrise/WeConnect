using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeConnect.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public string? Content { get; set; }
        public int Dislikes { get; set; }
        public int Timestamp { get; set; }
        public string? ImageURL { get; set; }
        public int? ThreadID { get; set; }
        public string? UserID { get; set; }

        [ForeignKey("ThreadID")]
        [ValidateNever]
        public Threads? ThreadSubscribed { get; set; }

        [ForeignKey("UserID")]
        [ValidateNever]
        public ApplicationUser? Author { get; set; }
}
}
