using Microsoft.AspNetCore.Mvc;
using WearHouse_API_Revision.Datas;
using WearHouse_API_Revision.Helpers;
using WearHouse_API_Revision.Outputs;

namespace WearHouse_API_Revision.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private UserHelper userHelper;
        public UserController(UserHelper userHelper)
        {
            this.userHelper = userHelper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.payload = userHelper.InsertUser(request);
                if (objJSON.payload == null) return NotFound("User Already Exist");
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.payload = userHelper.GetUser(request);
                if (objJSON.payload == null) return NotFound("Wrong Credential");
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
