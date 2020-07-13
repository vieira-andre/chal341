using chal341.Contracts;
using chal341.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("fee/{Segment}")]
        public async Task<GetExchangeFeeResponse> GetExchangeFeeAsync([FromRoute] GetExchangeFeeRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("fees")]
        public async Task<IList<GetExchangeFeeResponse>> GetExchangeFeesAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("fee")]
        public async Task<IActionResult> AddExchangeFeeAsync([FromBody] AddExchangeFeeRequest request)
        {
            await _segmentOpsService.AddExchangeFeeAsync(request);

            return Ok();
        }
    }
}
