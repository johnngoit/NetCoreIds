--CREATE USER [User]
--	WITHOUT LOGIN
--	WITH DEFAULT_SCHEMA = dbo

--GO

--GRANT CONNECT TO [User]
go 

CREATE LOGIN cyberproduct   
    WITH PASSWORD = 'x2000';  
USE IDSDB;  
CREATE USER cyberproductuser FOR LOGIN cyberproduct   
    WITH DEFAULT_SCHEMA = dbo;  
GO 

USE IDSDB;
GO
ALTER ROLE db_owner ADD MEMBER cyberproductuser;