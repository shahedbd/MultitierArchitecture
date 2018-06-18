CREATE TABLE [dbo].[Employee] (
    [ID]      BIGINT      IDENTITY (1, 1) NOT NULL,
    [Name]    NCHAR (100) NULL,
    [Contact] NCHAR (100) NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([ID] ASC)
);

