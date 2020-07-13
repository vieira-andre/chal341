using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
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

        public async Task<Document> GetExchangeFeeAsync(Document request)
        {
            return await _table.GetItemAsync(request);
        }
    }
}
