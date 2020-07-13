using chal341.Contracts;
using chal341.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chal341.Controllers
{
    [ApiController]
    [Route("api/segment")]
    [Produces("application/json")]
    public class SegmentOpsController : ControllerBase
    {
        private readonly ISegmentOpsService _segmentOpsService;

        public SegmentOpsController(ISegmentOpsService segmentOpsService)
        {
            _segmentOpsService = segmentOpsService;
        }

        /// <summary>
        /// Retrieves the exchange fee set for a given client segment.
        /// </summary>
        [HttpGet("fee/{Segment}")]
        public async Task<ActionResult<GetExchangeFeeResponse>> GetExchangeFeeAsync([FromRoute] GetExchangeFeeRequest request)
        {
            var result = await _segmentOpsService.GetExchangeFeeAsync(request);

            if (result is null)
                return NotFound(request);

            return Ok(result);
        }

        /// <summary>
        /// Retrieves all the exchange fees set.
        /// </summary>
        [HttpGet("fees")]
        public async Task<ActionResult<IEnumerable<GetExchangeFeeResponse>>> GetAllExchangeFeesAsync()
        {
            var results = await _segmentOpsService.GetAllExchangeFeesAsync();

            if (!results.Any())
                return NoContent();

            return Ok(results);
        }

        /// <summary>
        /// Sets the exchange fee for the provided client segment. In case it already exists, the value is updated.
        /// </summary>
        [HttpPut("fee")]
        public async Task<IActionResult> AddExchangeFeeAsync([FromBody] AddExchangeFeeRequest request)
        {
            await _segmentOpsService.AddExchangeFeeAsync(request);

            return Ok();
        }
    }
}
