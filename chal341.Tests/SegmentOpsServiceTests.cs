using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using chal341.Mappers;
using chal341.Models;
using chal341.Repositories;
using chal341.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace chal341.Tests
{
    public class SegmentOpsServiceTests
    {
        private readonly ISegmentOpsService _segmentOpsService;
        private readonly Mock<IExchangeFeeRepository> _exchangeFeeRepositoryMock = new Mock<IExchangeFeeRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public SegmentOpsServiceTests()
        {
            _segmentOpsService = new SegmentOpsService(_exchangeFeeRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddExchangeFeeAsync_ShouldSucceed()
        {
            // Arrange
            var request = new AddExchangeFeeRequest { Segment = CustomerSegment.RETL, Fee = "0.5" };
            var document = new Document { ["CustomerSegment"] = "RETL", ["FeeCharged"] = "0.5" };

            _mapperMock.Setup(x => x.ToDocumentModel(request)).Returns(document);
            _exchangeFeeRepositoryMock.Setup(x => x.SaveExchangeFeeAsync(document)).Returns(Task.CompletedTask);

            // Act
            await _segmentOpsService.AddExchangeFeeAsync(request);

            // Assert
            _exchangeFeeRepositoryMock.Verify(x => x.SaveExchangeFeeAsync(document), Times.Once);
        }
    }
}
