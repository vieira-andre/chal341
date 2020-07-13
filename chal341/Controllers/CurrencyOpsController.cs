using chal341.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chal341.Controllers
{
    [ApiController]
    [Route("api/currency")]
    [Produces("application/json")]
    public class CurrencyOpsController : ControllerBase
    {
        [HttpGet("price")]
        public async Task<ActionResult<GetPriceQuotationResponse>> GetPriceQuotation([FromQuery] GetPriceQuotationRequest request)
        {
            return Ok();
        }
    }
}
