-- 1- Database creation
CREATE DATABASE CDC_COMMAND_DB;

Use CDC_COMMAND_DB
GO

-- 2- Table creation
CREATE TABLE Person (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    Phone VARCHAR(11)
)

-- Enable CDC
EXEC sys.sp_cdc_enable_db
GO


-- CDC Creation to Person table
EXEC sys.sp_cdc_enable_table
@source_schema = N'dbo',
@source_name   = N'Person',
@role_name     = N'Admin',
@supports_net_changes = 1
GO