using chal341.Contracts;
using chal341.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chal341.Controllers
{
    [ApiController]
    [Route("api/segment")]
    [Produces("application/json")]
    public class SegmentOpsController : ControllerBase
    {
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
        public async Task<IActionResult> SetExchangeFeeAsync([FromBody] SetExchangeFeeRequest request)
        {
            return new GetExchangeFeeResponse { Segment = request.Segment, FeeCharged = request.Fee };

            return Ok();
        }
    }
}
