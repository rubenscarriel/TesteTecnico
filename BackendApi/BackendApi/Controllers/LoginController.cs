using BackendApi.Business;
using BackendApi.Model;
using BackendApi.Security.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginBusiness _loginBusiness;

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return Ok(_loginBusiness.FindByLogin(user));
        }
    }
}
