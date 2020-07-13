using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using System.Collections.Generic;

namespace chal341.Mappers
{
    public interface IMapper
    {
        Document ToDocumentModel(AddExchangeFeeRequest request);

        Document ToDocumentModel(GetExchangeFeeRequest request);

        GetExchangeFeeResponse ToContract(Document item);

        IEnumerable<GetExchangeFeeResponse> ToContract(IEnumerable<Document> items);
    }
}
