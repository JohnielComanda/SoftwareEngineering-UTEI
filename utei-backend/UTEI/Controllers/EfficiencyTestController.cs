using Microsoft.AspNetCore.Mvc;
using UTEI.Dtos;
using UTEI.Service.EnhanceUnitTest;

namespace UTEI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EfficiencyTestController : ControllerBase
    {
        private readonly IEfficiencyTestService _efficiencyService;
        private readonly ILogger _logger;
        public EfficiencyTestController(IEfficiencyTestService efficiencyService, ILogger<EfficiencyTestController> logger)
        {
            _efficiencyService = efficiencyService;
            _logger = logger;       
        }

        [HttpPost]
        public async Task<ActionResult> CreateEfficiencyTest([FromBody]EfficiencyTestCreationDto efficiencyTest)
        {
            try
            {
                var newTest = await _efficiencyService.CreateTest(efficiencyTest);
                return StatusCode(201, newTest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("all/{id}")]
        public async Task<ActionResult> GetAllSavedTest(string id)
        {
            try
            {
                var test = await _efficiencyService.GetAllSavedTest(id);
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

        [HttpGet]
        public async Task<ActionResult> GetSavedTest(string id)
        {
            try
            {
                var test = await _efficiencyService.GetSavedTest(id);
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
