using System.Threading.Tasks;
using Application.CQRS.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Controllers.Abstraction;

namespace Presentation.API.Controllers.Realisation
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : MyBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] CreateUserCommand request)
        {
            string userId = await Mediator.Send(request);
            return Ok(userId);
        }
    }
}