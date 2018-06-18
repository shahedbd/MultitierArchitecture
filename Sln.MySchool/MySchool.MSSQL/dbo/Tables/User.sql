CREATE TABLE [dbo].[User] (
    [UserId]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NULL,
    [LastName]    NVARCHAR (50) NULL,
    [EMail]       NVARCHAR (50) NULL,
    [Address]     NVARCHAR (50) NULL,
    [PhoneNo]     NVARCHAR (50) NULL,
    [Company]     NVARCHAR (50) NULL,
    [Designation] NVARCHAR (50) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

