using BackendApi.Business;
using BackendApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserBusiness _userBusiness;

        public UsersController()
        {

        }

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            return Ok(_userBusiness.Create(user));
        }
    }
}
