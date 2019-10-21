USE [IDSDB]
GO

/****** Object: Table [dbo].[Alerts] Script Date: 10/13/2019 9:39:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].SensorEventLog (
    [LogId]         INT              IDENTITY (1, 1) NOT NULL,
    [SensorId]    NVARCHAR(50) Not null,
    [SourceAddress]        NVARCHAR (50)    NULL,
    [SourcePort]      NVARCHAR(15)              NULL,
    [DestinationAddress]   NVARCHAR (50)    NULL,
    [DestinationPort] INT              NULL,
	TimeVal NVARCHAR(50) NULL,
    [Payload]         NVARCHAR (255)   NULL,
    [Created]         DATETIME         NOT NULL
);


