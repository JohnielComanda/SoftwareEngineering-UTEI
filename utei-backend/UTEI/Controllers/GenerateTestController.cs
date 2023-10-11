using Microsoft.AspNetCore.Mvc;
using UTEI.Dtos;
using UTEI.Service.GenerateUnitTest;

namespace UTEI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GenerateTestController : ControllerBase
    {
        private readonly IGenerateTestService _generateService;
        private readonly ILogger<GenerateTestController> _logger;
        public GenerateTestController(IGenerateTestService generateService, ILogger<GenerateTestController> logger)
        {
            _generateService = generateService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostGenerateTest([FromBody] GenerateTestCreationDto generateTestCreationDto)
        {
            try
            {
                var generateTest = await _generateService.CreateTest(generateTestCreationDto);
                return StatusCode(201, generateTest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong!");
            }

        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllSavedTest()
        {
            try
            {
                var test = await _generateService.GetAllSavedTest();
                if(test == null)
                {
                    _logger.LogInformation("No test found");
                    return NotFound();
                }
                return Ok(test);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSavedTest(string id)
        {
            try
            {
                var test = await _generateService.GetSavedTest(id);
                if (test == null)
                {
                    _logger.LogInformation("No test found");
                    return NotFound();
                }
                return Ok(test);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
