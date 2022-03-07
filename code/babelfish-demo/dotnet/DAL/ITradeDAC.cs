using System;
using System.Collections.Generic;
using DTL;

namespace DAL
{
    public interface ITradeDAC
    {
        TradeDTO RestoreTrade(long tradeId);
        void StoreTrade(TradeDTO trade);
        IEnumerable<TradeDTO> RestorePage(int startPage, int pageSize);
    }
}
