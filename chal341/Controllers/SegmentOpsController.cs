using chal341.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
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
            throw new NotImplementedException();
        }

        [HttpGet("fees")]
        public async Task<IList<GetExchangeFeeResponse>> GetExchangeFeesAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("fee")]
        public async Task<GetExchangeFeeResponse> SetExchangeFeeAsync([FromBody] SetExchangeFeeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
