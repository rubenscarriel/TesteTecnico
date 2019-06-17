using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoBackendApi.Model;

namespace TesteTecnicoBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var list = new List<User>();
            list.Add(new User()
            {
                Id = 1,
                Login = "blabla",
                Password = "bla123",
                Email = "email@email.com"
            });

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return Ok(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
