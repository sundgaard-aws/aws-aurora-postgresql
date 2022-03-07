using System;

namespace DTL
{
    public class TradeDTO
    {
        public Nullable<long> TradeId { get; set; }
        public Decimal TradeAmount { get; set; }
        public Nullable<DateTime> TradeDate { get; set; }

        public override string ToString()
        {
            return $"TradeId:{TradeId.Value},TradeAmount:{TradeAmount}";
        }
    }
}
