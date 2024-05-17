using DotNetTask.Data;
using DotNetTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            this._user = user;
        }

        [HttpGet("user/{Id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string Id)
        {
            try
            {
            var users = await _user.GetUser(Id);
            return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
