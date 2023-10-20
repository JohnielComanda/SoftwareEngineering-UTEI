using Microsoft.AspNetCore.Mvc;
using UTEI.Dtos;
using UTEI.Service.User;

namespace UTEI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegisterService _service;
        private readonly ILogger<GenerateTestController> _logger;
        public UserRegistrationController(IUserRegisterService service, ILogger<GenerateTestController> logger)
        {
            _service = service;
            _logger = logger;

        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody]UserCreationDto userCreationDto)
        {
            try
            {
                var result = await _service.CreateUser(userCreationDto);
                if (result != null)
                {
                    return StatusCode(201, result);
                }
                return BadRequest();


            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
