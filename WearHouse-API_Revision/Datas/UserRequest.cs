using System.ComponentModel.DataAnnotations;

namespace WearHouse_API_Revision.Datas
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string UserEmail { get; set; }
        [Required] 
        public string UserPassword { get; set; }
    }
    public class LoginRequest
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }

}
