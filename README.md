# Connecting via SQL Server Management Studio (SSMS)
Remember to connect via "New Query" to avoid getting an "invalid cast exception", as the database object explorer does not work with the PostgreSQL schemas.

``` sql
create database trade_db;

create table trades  (
trade_id int, 
trade_type nvarchar(50)
);

insert into trades values (1, 'FX Swap');
insert into trades values (2, 'FX Option');

select * from trades;
```
=======
# aws-aurora-postgresql
Demo on using Aurora PostgreSQL and Babelfish.
