﻿using System;

namespace chal341.Models
{
    public class ExchangeFee : IExchangeFee
    {
        public ExchangeFee(string segment, decimal feeCharged)
        {
            ValidateSegment(segment);
            FeeCharged = feeCharged;
        }

        public CustomerSegment Segment { get; private set; }

        public decimal FeeCharged { get; private set; }

        private void ValidateSegment(string segment)
        {
            if (Enum.TryParse(segment, out CustomerSegment result) && !result.Equals(default))
                Segment = result;
            else
                throw new ArgumentException("The provided value is not a valid client segment.");
        }
    }
}
