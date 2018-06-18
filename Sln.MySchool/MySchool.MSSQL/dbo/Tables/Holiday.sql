CREATE TABLE [dbo].[Holiday] (
    [SL]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [HolidayStartDate] DATETIME       NULL,
    [HolidayEndDate]   DATETIME       NULL,
    [Notes]            NVARCHAR (350) NULL,
    [Status]           TINYINT        NULL,
    CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED ([SL] ASC)
);

