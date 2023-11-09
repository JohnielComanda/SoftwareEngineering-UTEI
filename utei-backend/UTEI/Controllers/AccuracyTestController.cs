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
        private readonly IAccuracyTestService accuService;
        public AccuracyTestController(IAccuracyTestService acc)
        {
            accuService = acc;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccuracyTest([FromBody] AccuracyTestDto info)
        {
            try
            {
                var res = await accuService.TestAccuracy(info);
                return StatusCode(201, res);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong!");
            }
        }
    }
}
