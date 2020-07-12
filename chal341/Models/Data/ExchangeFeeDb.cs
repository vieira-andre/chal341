using Amazon.DynamoDBv2.DataModel;

namespace chal341.Models.Data
{
    [DynamoDBTable("ExchangeFee")]
    public class ExchangeFeeDb
    {
        [DynamoDBHashKey]
        public string ClientSegment { get; set; }

        public decimal FeeCharged { get; set; }
    }
}
