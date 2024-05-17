using WearHouse_API_Revision.Models;

namespace WearHouse_API_Revision.Outputs
{
    public class ListCategoryOutput
    {
        public List<Category>? payload { get; set; }
        public ListCategoryOutput()
        {
            payload = new List<Category>();
        }
    }
    public class CategoryOutput
    {
        public Category payload { get; set; }
    }
}
