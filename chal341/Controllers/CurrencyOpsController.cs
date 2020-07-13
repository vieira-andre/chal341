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

        /// <summary>
        /// Returns the price quotation (BRL) considering both the amount of foreign currency and the client segment provided.
        /// </summary>
        [HttpGet("price")]
        public async Task<ActionResult<GetPriceQuotationResponse>> GetPriceQuotationAsync([FromQuery] GetPriceQuotationRequest request)
        {
            var result = await _currencyOpsService.GetPriceQuotationAsync(request);

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        /// <summary>
        /// Returns the exchange rate between BRL and a given foreign currency.
        /// </summary>
        [HttpGet("exchangeRate/{Code}")]
        public async Task<ActionResult<GetExchangeRateResponse>> GetExchangeRateAsync([FromRoute] GetExchangeRateRequest request)
        {
            var result = await _currencyOpsService.GetExchangeRateAsync(request);

            return Ok(result);
        }
    }
}
