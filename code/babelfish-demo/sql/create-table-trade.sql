DROP TABLE IF EXISTS trade
GO
CREATE TABLE [dbo].[trade](
	[trade_id] [bigint] IDENTITY PRIMARY KEY,
	[trade_type] [int],
	[trade_date] [date],
	[trader_id] [int],
	[trade_amount] [decimal](18, 2),
	[counterparty_id] [int]
) ON [PRIMARY]
insert into trades values (null, 'FX Swap');
insert into trades values (null, 'FX Option');