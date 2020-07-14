using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using chal341.Helpers;
using chal341.Mappers;
using chal341.Models;
using chal341.Repositories;
using chal341.Services;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace chal341.Tests
{
    public class CurrencyOpsServiceTests
    {
        private readonly CurrencyOpsService _currencyOpsService;
        private readonly Mock<IExchangeFeeRepository> _exchangeFeeRepositoryMock = new Mock<IExchangeFeeRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IUtils> _utils = new Mock<IUtils>();

        public CurrencyOpsServiceTests()
        {
            _currencyOpsService = new CurrencyOpsService(_exchangeFeeRepositoryMock.Object, _mapperMock.Object, _utils.Object);
        }

        [Fact]
        public async Task GetPriceQuotationAsync_ShouldReturnCorrectPriceQuotation_WhenTheSegmentFeeExists()
        {
            // Arrange
            var request = new GetPriceQuotationRequest { Code = "USD", Amount = "1", Segment = ClientSegment.RETL };
            var document = new Document { ["ClientSegment"] = "RETL" };
            var responseFromDb = new Document { ["ClientSegment"] = "RETL", ["FeeCharged"] = "0.5" };

            var responseAsString = "{\"rates\":{\"BRL\":5.3397475505},\"base\":\"USD\",\"date\":\"2020-07-13\"}";

            var exchangeFee = new GetExchangeFeeResponse
            {
                Segment = ClientSegment.RETL,
                FeeCharged = 0.5M
            };

            Environment.SetEnvironmentVariable("ExchangeApiUrl", "url");
            Environment.SetEnvironmentVariable("ExchangeApiPath", "path");
            Environment.SetEnvironmentVariable("HomeCurrency", "BRL");

            _utils.Setup(x => x.ExecuteHttpRequestAsync(It.IsAny<HttpMethod>(), It.IsAny<string>(), null)).ReturnsAsync(responseAsString);
            _mapperMock.Setup(x => x.ToDocumentModel(request)).Returns(document);
            _exchangeFeeRepositoryMock.Setup(x => x.GetExchangeFeeAsync(document)).ReturnsAsync(responseFromDb);
            _mapperMock.Setup(x => x.ToContract(responseFromDb)).Returns(exchangeFee);

            // Act
            var response = await _currencyOpsService.GetPriceQuotationAsync(request);

            // Assert
            Assert.Equal(request.Segment, response.Segment);
            Assert.Equal($"5.3664462882525 BRL", response.Price);
        }
    }
}
