using Amazon.DynamoDBv2.DocumentModel;
using chal341.Contracts;
using chal341.Models.Data;

namespace chal341.Mappers
{
    public interface IMapper
    {
        Document ToDocumentModel(AddExchangeFeeRequest request);
    }
}
