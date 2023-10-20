using Microsoft.AspNetCore.Mvc;
using UTEI.Dtos;
using UTEI.Service.User;

namespace UTEI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;
        private readonly ILogger<UserLoginController> _logger;
        public UserLoginController(IUserLoginService service, ILogger<UserLoginController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            try
            {
                var result = await _service.GetUserById(id);

                if (result != null)
                {
                    return StatusCode(201, result);
                }
                else
                {
                    return NotFound(); // Return a 404 Not Found response
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Email/{email}")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            try
            {
                var result = await _service.GetUserByEmail(email);

                if (result != null)
                {
                    return StatusCode(201, result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UserLogin([FromBody]UserLoginDto userLoginDto)
        {
            try
            {
                 var result = await _service.UserLogin(userLoginDto);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
