using Amazon.DynamoDBv2.DocumentModel;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public interface IExchangeFeeRepository
    {
        Task AddExchangeFeeAsync(Document exchangeFeeDb);

        Task<Document> GetExchangeFeeAsync(Document request);
    }
}
