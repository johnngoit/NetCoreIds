IF EXISTS (SELECT * FROM sys.tables WHERE name = 'SensorHeartbeatLog' AND type = 'U') DROP TABLE dbo.SensorHeartbeatLog;
CREATE TABLE [dbo].[SensorHeartbeatLog]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [SensorId] NVARCHAR(50) NOT NULL, 
    [Created] DATETIME NULL,
    [Filter] NVARCHAR(50) NULL
)
