CREATE TABLE [dbo].[Branch] (
    [ID]       BIGINT      IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (100) NULL,
    [Location] NCHAR (100) NULL,
    CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED ([ID] ASC)
);

