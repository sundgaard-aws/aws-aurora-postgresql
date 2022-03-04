using System;
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
    }
}
