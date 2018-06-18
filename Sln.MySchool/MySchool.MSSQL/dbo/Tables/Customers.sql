CREATE TABLE [dbo].[Customers] (
    [CustomerId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (250) NULL,
    [Address]    VARCHAR (250) NULL,
    [MobileNo]   VARCHAR (20)  NULL,
    [Birthdate]  DATETIME      NULL,
    [EmailId]    VARCHAR (100) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

