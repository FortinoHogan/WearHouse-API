using System.ComponentModel.DataAnnotations;

namespace WearHouse_API_Revision.Datas
{
    public class CategoryRequest
    {
        public Guid? CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
    public class NameCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
