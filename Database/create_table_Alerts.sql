CREATE TABLE [dbo].[Alerts]
(
	[AlertId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [DatasourceId] UNIQUEIDENTIFIER NOT NULL, 
    [Sourceip] NVARCHAR(15) NULL, 
    [SourcePort] INT NULL, 
    [DestinationIp] NVARCHAR(15) NULL, 
    [DestinationPort] INT NULL, 
    [Payload] NVARCHAR(255) NULL, 
    [Captured] TIMESTAMP NULL, 
    [Created] DATETIME NOT NULL
)