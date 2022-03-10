SELECT @@VERSION AS version

SELECT aurora_version() AS aurora_version 

SELECT
aurora_version() as aurora_version,
version() as postgresql_version,
sys.version() as Babelfish_compatibility,
sys.SERVERPROPERTY('BabelfishVersion') as Babelfish_Version