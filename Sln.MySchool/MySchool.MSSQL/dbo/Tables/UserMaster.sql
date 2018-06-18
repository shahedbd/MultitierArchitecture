CREATE TABLE [dbo].[UserMaster] (
    [UserID]       BIGINT          IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (50)   NOT NULL,
    [FirstName]    NVARCHAR (150)  NULL,
    [LastName]     NVARCHAR (150)  NULL,
    [Email]        NVARCHAR (150)  NULL,
    [GenderCode]   TINYINT         NULL,
    [DateOfBirth]  DATETIME        NULL,
    [PhoneNumber]  NVARCHAR (50)   NULL,
    [Address]      NVARCHAR (250)  NULL,
    [DivisionCode] TINYINT         NULL,
    [HASH]         NVARCHAR (MAX)  NOT NULL,
    [SALT]         VARBINARY (512) NOT NULL,
    [Status]       TINYINT         NULL,
    CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

