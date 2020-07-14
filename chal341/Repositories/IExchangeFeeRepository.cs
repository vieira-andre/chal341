using Amazon.DynamoDBv2.DocumentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public interface IExchangeFeeRepository
    {
        Task SaveExchangeFeeAsync(Document exchangeFeeDb);

        Task<Document> GetExchangeFeeAsync(Document request);

        Task<IEnumerable<Document>> GetAllExchangeFeesAsync();
    }
}
