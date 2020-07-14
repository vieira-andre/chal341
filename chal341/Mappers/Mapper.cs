using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using chal341.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace chal341.Mappers
{
    public class Mapper : IMapper
    {
        public GetExchangeFeeResponse ToContract(Document item)
        {
            return item is null
                ? default
                : new GetExchangeFeeResponse
                    {
                        Segment = item["ClientSegment"].AsString().ParseFromString(),
                        FeeCharged = item["FeeCharged"].AsString().ToInvariantDecimal()
                    };
        }

        public IEnumerable<GetExchangeFeeResponse> ToContract(IEnumerable<Document> items)
        {
            return items.Select(ToContract);
        }

        public Document ToDocumentModel(AddExchangeFeeRequest request)
        {
            return new Document
            {
                ["ClientSegment"] = request.Segment.ToString(),
                ["FeeCharged"] = request.Fee.ToInvariantDecimal()
            };
        }

        public Document ToDocumentModel(GetExchangeFeeRequest request)
        {
            return new Document
            {
                ["ClientSegment"] = request.Segment.ToString()
            };
        }

        public Document ToDocumentModel(GetPriceQuotationRequest request)
        {
            return new Document
            {
                ["ClientSegment"] = request.Segment.ToString()
            };
        }
    }
}
