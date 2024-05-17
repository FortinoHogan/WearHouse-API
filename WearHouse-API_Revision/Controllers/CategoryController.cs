using Microsoft.AspNetCore.Mvc;
using WearHouse_API_Revision.Datas;
using WearHouse_API_Revision.Helpers;
using WearHouse_API_Revision.Outputs;

namespace WearHouse_API_Revision.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private CategoryHelper categoryHelper;
        public CategoryController(CategoryHelper categoryHelper)
        {
            this.categoryHelper = categoryHelper;
        }
        [HttpPost("")]
        public async Task<IActionResult> GetCategory([FromBody] CategoryRequest request)
        {
            try
            { 
                var objJSON = new ListCategoryOutput();
                objJSON.payload = categoryHelper.GetCategory(request);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<IActionResult> InsertCategory([FromBody] NameCategoryRequest request)
        {
            try
            {
                var objJSON = new CategoryOutput();
                objJSON.payload = categoryHelper.InsertCategory(request);
                return new OkObjectResult(objJSON);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("edit")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryRequest request)
        {
            try
            {
                var objJSON = new CategoryOutput();
                objJSON.payload = categoryHelper.UpdateCategory(request);
                if(objJSON.payload == null) return NotFound("Category Doesn't Exist");
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryRequest request)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = categoryHelper.DeleteCategory(request);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
