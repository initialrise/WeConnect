using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeConnect.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public int Turegno { get; set; }
        public int ThreadID { get; set; }

        [ForeignKey("ThreadID")]
        [ValidateNever]
        public Threads? ThreadSubscribed { get; set; }
    }
}
