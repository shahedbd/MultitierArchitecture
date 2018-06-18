CREATE TABLE [dbo].[Designation] (
    [ID]          BIGINT      IDENTITY (1, 1) NOT NULL,
    [Title]       NCHAR (100) NULL,
    [Description] NCHAR (100) NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

