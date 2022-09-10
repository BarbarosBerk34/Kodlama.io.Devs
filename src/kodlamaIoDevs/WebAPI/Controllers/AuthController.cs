using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisteredUserDto result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
        {
            LoggedInUserDto result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }
    }
}
