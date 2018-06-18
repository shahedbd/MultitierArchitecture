CREATE TABLE [dbo].[Contact] (
    [Id]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (150) NULL,
    [Address] NVARCHAR (250) NULL,
    [City]    NVARCHAR (50)  NULL,
    [Country] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

