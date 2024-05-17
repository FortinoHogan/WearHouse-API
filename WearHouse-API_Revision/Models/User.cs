using System.ComponentModel.DataAnnotations;

namespace WearHouse_API_Revision.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
