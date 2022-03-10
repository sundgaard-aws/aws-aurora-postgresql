DROP FUNCTION IF EXISTS price_trade_fn
GO
CREATE FUNCTION price_trade_fn (@trade_id int)
RETURNS decimal(10,2)
BEGIN
	DECLARE @price decimal(10,2)
	PRINT 'Start price_trade_fn...'
	set @price = RAND()*500
	PRINT 'End price_trade_fn...'
	RETURN(@price)
END;