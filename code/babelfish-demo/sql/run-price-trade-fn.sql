
begin
	declare @price decimal(10,2)
	set @price = price_trade_fn(1)
	print(concat('price=',@price))
end