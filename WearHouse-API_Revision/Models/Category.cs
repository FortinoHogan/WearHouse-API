using System.ComponentModel.DataAnnotations;

namespace WearHouse_API_Revision.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
