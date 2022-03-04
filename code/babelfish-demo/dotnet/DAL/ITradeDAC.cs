using System;
using DTL;

namespace DAL
{
    public interface ITradeDAC
    {
        void StoreTrade(TradeDTO trade);
    }
}
