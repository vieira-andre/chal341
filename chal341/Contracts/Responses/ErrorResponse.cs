using chal341.Models;
using System.Collections.Generic;

namespace chal341.Contracts
{
    public class ErrorResponse
    {
        public IList<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
