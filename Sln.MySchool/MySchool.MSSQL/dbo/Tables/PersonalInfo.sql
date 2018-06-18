CREATE TABLE [dbo].[PersonalInfo] (
    [PersonalInfoID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (150) NULL,
    [LastName]       NVARCHAR (150) NULL,
    [DateOfBirth]    DATETIME       NULL,
    [City]           NVARCHAR (150) NULL,
    [Country]        NVARCHAR (150) NULL,
    [MobileNo]       NVARCHAR (150) NULL,
    [NID]            NVARCHAR (150) NULL,
    [Email]          NVARCHAR (150) NULL,
    [Status]         TINYINT        NULL,
    CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED ([PersonalInfoID] ASC)
);

