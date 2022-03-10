create database dms_demo_db

using dms_demo_db

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[counterparty](
	[counterparty_id] [int] NOT NULL,
	[counterparty_short_name] [nvarchar](50) NOT NULL,
	[counterparty_full_name] [nvarchar](250) NOT NULL
) ON [PRIMARY]
GO