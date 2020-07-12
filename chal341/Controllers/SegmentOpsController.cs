using chal341.Contracts;
using chal341.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chal341.Controllers
{
    [ApiController]
    [Route("api/segment")]
    public class SegmentOpsController : ControllerBase
    {
        [HttpGet("fee/{segment}")]
        public async Task<GetExchangeFeeResponse> GetExchangeFeeAsync([FromRoute] GetExchangeFeeRequest request)
        {
            return new GetExchangeFeeResponse { Segment = request.Segment, FeeCharged = 5.66M };
        }

        [HttpGet("fees")]
        public async Task<IList<GetExchangeFeeResponse>> GetExchangeFeesAsync()
        {
            return new List<GetExchangeFeeResponse>() { new GetExchangeFeeResponse { Segment = ClientSegment.PRIV, FeeCharged = 5.66M },
                new GetExchangeFeeResponse { Segment = ClientSegment.PSNL, FeeCharged = 5.66M } };
        }

        [HttpPost("fee")]
        public async Task<GetExchangeFeeResponse> SetExchangeFeeAsync([FromBody] SetExchangeFeeRequest request)
        {
            return new GetExchangeFeeResponse { Segment = request.Segment, FeeCharged = request.Fee };
        }
    }
}
