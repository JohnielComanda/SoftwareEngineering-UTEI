using Microsoft.AspNetCore.Mvc;
using UTEI.Dtos;
using UTEI.Models;
using UTEI.Service.AccuracyUnitTest;
using UTEI.Service.EnhanceUnitTest;

namespace UTEI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccuracyTestController : ControllerBase
    {
        private readonly IAccuracyTestService _accuService;
        public AccuracyTestController(IAccuracyTestService accuService)
        {
            _accuService = accuService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccuracyTest([FromBody] AccuracyTestDto info)
        {
            try
            {
                var res = await _accuService.TestAccuracy(info);
                return StatusCode(201, res);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("all/{id}")]
        public async Task<ActionResult> GetAllSavedTest(string id)
        {
            try
            {
                var test = await _accuService.GetAllSavedTest(id);
                if (test == null)
                {
                    return NotFound();
                }
                return Ok(test);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSavedTest(string id)
        {
            try
            {
                var test = await _accuService.GetSavedTest(id);
                if (test == null)
                {
                    return NotFound();
                }
                return Ok(test);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
