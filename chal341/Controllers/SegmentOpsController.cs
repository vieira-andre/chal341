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
        [HttpGet]
        public async Task<GetExchangeFeeResponse> GetExchangeFeeAsync([FromRoute] GetExchangeFeeRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IList<GetExchangeFeeResponse>> GetExchangeFeesAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<GetExchangeFeeResponse> SetExchangeFeeAsync([FromBody] SetExchangeFeeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
