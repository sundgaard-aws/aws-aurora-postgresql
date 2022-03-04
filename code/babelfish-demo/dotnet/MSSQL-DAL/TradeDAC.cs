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

        public TradeDAC(IConfigurationRoot configurationRoot) {
            this.configurationRoot = configurationRoot;
        }
        public void StoreTrade(TradeDTO trade)
        {
            var connString = configurationRoot.GetConnectionString("babelfishdb");
            using (IDbConnection db = new SqlConnection(connString))
            {
                db.Open();
                //var trades = db.Query<List<TradeDTO>>("SELECT * from trade");
                //var trades = db.Query("SELECT * from trade");
                var trades = db.Query<dynamic>("SELECT * from trade").Select(item => new TradeDTO()
                {
                    TradeId = item.trade_id,
                    TradeAmount = item.trade_amount,
                    TradeDate = item.trade_date
                });
                                  
                var tradeRestored = trades.First();
                Console.WriteLine(tradeRestored);
            }
        }

        
    }
}
