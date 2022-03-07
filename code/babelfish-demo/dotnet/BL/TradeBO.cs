using System;
using System.Collections.Generic;
using DAL;
using DTL;

namespace BL
{
    public class TradeBO
    {
        private ITradeDAC tradeDAC;

        public TradeBO(ITradeDAC tradeDAC) {
            this.tradeDAC = tradeDAC;
        }
        public void BookTrade(TradeDTO trade) {
            tradeDAC.StoreTrade(trade);
        }

        public IEnumerable<TradeDTO> GetTradeList(int startPage, int pageSize)
        {
            return tradeDAC.RestorePage(startPage, pageSize);
        }
    }
}
