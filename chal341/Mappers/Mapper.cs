using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using chal341.Extensions;

namespace chal341.Mappers
{
    public class Mapper : IMapper
    {
        public GetExchangeFeeResponse ToContract(Document item)
        {
            return new GetExchangeFeeResponse
            {
                Segment = item["ClientSegment"].AsString().ParseFromString(),
                FeeCharged = item["FeeCharged"].AsString().ToDecimal()
            };
        }

        public Document ToDocumentModel(AddExchangeFeeRequest request)
        {
            return new Document
            {
                ["ClientSegment"] = request.Segment.ToString(),
                ["FeeCharged"] = request.Fee.ToDecimal()
            };
        }

        public Document ToDocumentModel(GetExchangeFeeRequest request)
        {
            return new Document
            {
                ["ClientSegment"] = request.Segment.ToString()
            };
        }
    }
}
