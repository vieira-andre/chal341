using chal341.Contracts;
using chal341.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chal341.Controllers
{
    [ApiController]
    [Route("api/currency")]
    [Produces("application/json")]
    public class CurrencyOpsController : ControllerBase
    {
        private readonly ICurrencyOpsService _currencyOpsService;

        public CurrencyOpsController(ICurrencyOpsService currencyOpsService)
        {
            _currencyOpsService = currencyOpsService;
        }

        [HttpGet("price")]
        public async Task<ActionResult<GetPriceQuotationResponse>> GetPriceQuotationAsync([FromQuery] GetPriceQuotationRequest request)
        {
            return Ok();
        }

        [HttpGet("prices")]
        public async Task<ActionResult<GetPriceQuotationResponse>> GetPriceQuotation([FromQuery] GetAllPriceQuotationsRequest request)
        {
            return Ok("All quotes");
        }
    }
}
