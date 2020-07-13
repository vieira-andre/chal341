using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using chal341.Models;
using chal341.Models.Data;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public class ExchangeFeeRepository : IExchangeFeeRepository
    {
        private readonly Table _table;

        public ExchangeFeeRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _table = Table.LoadTable(dynamoDbClient, "ExchangeFee");
        }

        public async Task AddExchangeFeeAsync(Document documentModel)
        {
            await _table.PutItemAsync(documentModel);
        }

        public Task<ExchangeFeeDb> GetExchangeFeeAsync(ClientSegment segment)
        {
            throw new System.NotImplementedException();
        }
    }
}
