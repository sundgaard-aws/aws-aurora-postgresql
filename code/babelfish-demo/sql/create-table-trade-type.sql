DROP TABLE IF EXISTS trade_type
GO
CREATE TABLE trade_type (
	[id] [bigint] IDENTITY NOT NULL PRIMARY KEY,
	[short_name] nvarchar(10) NOT NULL,
	[full_name] nvarchar(50) NOT NULL
) ON [PRIMARY]
GO
INSERT INTO trade_type VALUES ('FXS', 'FX Swap');
INSERT INTO trade_type VALUES ('FXO', 'FX Option');
INSERT INTO trade_type VALUES ('BOO', 'Bond Option');
