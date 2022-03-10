--https://docs.microsoft.com/en-us/sql/t-sql/statements/create-procedure-transact-sql?view=sql-server-ver15#Examples
--USE master -- master => master_dbo in babelfish_db
--GO
-- CREATE OR ALTER Not supported currently
DROP PROCEDURE IF EXISTS simple_tsql_procedure
GO
CREATE PROCEDURE simple_tsql_procedure AS
DECLARE  trade_cursor CURSOR FOR
    select * from trade
BEGIN
	PRINT 'Start anon block...'
	OPEN trade_cursor;  
  
	-- Perform the first fetch.  
	FETCH NEXT FROM trade_cursor;  
  
	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
	   -- This is executed as long as the previous fetch succeeds.
	   PRINT 'Found a row...'
	   FETCH NEXT FROM trade_cursor;  
	END  
  
	CLOSE trade_cursor;  
	DEALLOCATE trade_cursor;  
	PRINT 'End anon block...'
END