using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using chal341.Models;
using chal341.Models.Data;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public class ExchangeFeeRepository : IExchangeFeeRepository
    {
        private readonly DynamoDBContext _context;

        public ExchangeFeeRepository(IAmazonDynamoDB dymanoDbClient)
        {
            _context = new DynamoDBContext(dymanoDbClient);
        }

        public async Task AddExchangeFeeAsync(ExchangeFeeDb exchangeFeeDb)
        {
            await _context.SaveAsync(exchangeFeeDb);
        }

        public Task<ExchangeFeeDb> GetExchangeFeeAsync(ClientSegment segment)
        {
            throw new System.NotImplementedException();
        }
    }
}
