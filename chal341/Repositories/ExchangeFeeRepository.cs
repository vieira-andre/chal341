﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public class ExchangeFeeRepository : IExchangeFeeRepository
    {
        private readonly Table _table;

        public ExchangeFeeRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _table = Table.LoadTable(dynamoDbClient, Variables.TableName);
        }

        public async Task SaveExchangeFeeAsync(Document documentModel)
        {
            await _table.PutItemAsync(documentModel);
        }

        public async Task<Document> GetExchangeFeeAsync(Document request)
        {
            return await _table.GetItemAsync(request);
        }

        public async Task<IEnumerable<Document>> GetAllExchangeFeesAsync()
        {
            var config = new ScanOperationConfig();

            return await _table.Scan(config).GetRemainingAsync();
        }
    }
}
