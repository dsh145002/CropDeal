using CaseStudy.Dtos;
using CaseStudy.Models;
using CaseStudy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private RegisterService _registerService;
        public UserController(RegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(CreateUserDto user)
        {
            
                var res = await _registerService.RegisterUser(user);
                if(res == null)
                {
                    return BadRequest();
                }
                return Ok(res);
            
        }
    }
}
