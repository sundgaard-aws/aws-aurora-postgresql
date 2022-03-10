SELECT *
FROM INFORMATION_SCHEMA.TABLES
WHERE table_schema = 'master_dbo'
AND table_name not in ('sysdatabases')
ORDER BY table_type,table_name
