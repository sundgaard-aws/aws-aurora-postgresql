using System;
using System.Data;
using DAL;
using DTL;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MSSQL_DAL
{
    public class TradeDAC : ITradeDAC
    {
        private IConfigurationRoot configurationRoot;
        private SqlConnection db;

        public TradeDAC(IConfigurationRoot configurationRoot) {
            this.configurationRoot = configurationRoot;
            var connString = configurationRoot.GetConnectionString("babelfishdb");
            this.db = new SqlConnection(connString);
            db.Open();
        }

        public IEnumerable<TradeDTO> RestorePage(int startPage, int pageSize)
        {
            var trades = db.Query<dynamic>("SELECT * from trade").Select(item => new TradeDTO()
            {
                TradeId = item.trade_id,
                TradeAmount = item.trade_amount,
                TradeDate = item.trade_date
            });
                                
            var tradesRestored = trades.Skip(startPage*pageSize).Take(pageSize);
            Console.WriteLine(tradesRestored);
            return tradesRestored;
        }

        public TradeDTO RestoreTrade(long tradeId)
        {
            
            //var trades = db.Query<List<TradeDTO>>("SELECT * from trade");
            //var trades = db.Query("SELECT * from trade");
            var trades = db.Query<dynamic>("SELECT * from trade").Select(item => new TradeDTO()
            {
                TradeId = item.trade_id,
                TradeAmount = item.trade_amount,
                TradeDate = item.trade_date
            });
                                
            var tradeRestored = trades.SingleOrDefault();
            Console.WriteLine(tradeRestored);
            return tradeRestored;
        }

        public void StoreTrade(TradeDTO trade)
        {
            db.Execute("delete from trade where trade_id is null");            
            if(trade.TradeId == null || RestoreTrade(trade.TradeId.Value) == null) {
                trade.TradeId = db.QuerySingle<long>("select max(trade_id) from trade")+1;
                db.Execute("insert into trade(trade_amount,trade_id) values(@TradeAmount,@TradeId)", trade);
            }
            else
                db.Execute("update trade set trade_amount=@TradeAmount where trade_id=@TradeId", trade);
        }
    }
}
