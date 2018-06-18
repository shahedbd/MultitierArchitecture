USE [DevTest]
GO
/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 6/16/2018 6:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalInfo](
	[PersonalInfoID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[City] [nchar](50) NULL,
	[Country] [nchar](100) NULL,
	[MobileNo] [nchar](50) NULL,
	[NID] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED 
(
	[PersonalInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[PersonalInfo] ON 

GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (1, N'FirstName 0                                                                                         ', N'LastName 0                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 0                                            ', N'Country 0                                                                                           ', N'1723289239                                        ', N'12344232131234                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (2, N'FirstName 1                                                                                         ', N'LastName 1                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 1                                            ', N'Country 1                                                                                           ', N'1723289240                                        ', N'12344232131235                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (3, N'FirstName 2                                                                                         ', N'LastName 2                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 2                                            ', N'Country 2                                                                                           ', N'1723289241                                        ', N'12344232131236                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (4, N'FirstName 3                                                                                         ', N'LastName 3                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 3                                            ', N'Country 3                                                                                           ', N'1723289242                                        ', N'12344232131237                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (5, N'FirstName 4                                                                                         ', N'LastName 4                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 4                                            ', N'Country 4                                                                                           ', N'1723289243                                        ', N'12344232131238                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (6, N'FirstName 5                                                                                         ', N'LastName 5                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 5                                            ', N'Country 5                                                                                           ', N'1723289244                                        ', N'12344232131239                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (7, N'FirstName 6                                                                                         ', N'LastName 6                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 6                                            ', N'Country 6                                                                                           ', N'1723289245                                        ', N'12344232131240                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (8, N'FirstName 7                                                                                         ', N'LastName 7                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 7                                            ', N'Country 7                                                                                           ', N'1723289246                                        ', N'12344232131241                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (9, N'FirstName 8                                                                                         ', N'LastName 8                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 8                                            ', N'Country 8                                                                                           ', N'1723289247                                        ', N'12344232131242                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (10, N'FirstName 9                                                                                         ', N'LastName 9                                                                                          ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 9                                            ', N'Country 9                                                                                           ', N'1723289248                                        ', N'12344232131243                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (11, N'FirstName 10                                                                                        ', N'LastName 10                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 10                                           ', N'Country 10                                                                                          ', N'1723289249                                        ', N'12344232131244                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (12, N'FirstName 11                                                                                        ', N'LastName 11                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 11                                           ', N'Country 11                                                                                          ', N'1723289250                                        ', N'12344232131245                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (13, N'FirstName 12                                                                                        ', N'LastName 12                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 12                                           ', N'Country 12                                                                                          ', N'1723289251                                        ', N'12344232131246                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (14, N'FirstName 13                                                                                        ', N'LastName 13                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 13                                           ', N'Country 13                                                                                          ', N'1723289252                                        ', N'12344232131247                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (15, N'FirstName 14                                                                                        ', N'LastName 14                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 14                                           ', N'Country 14                                                                                          ', N'1723289253                                        ', N'12344232131248                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (16, N'FirstName 15                                                                                        ', N'LastName 15                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 15                                           ', N'Country 15                                                                                          ', N'1723289254                                        ', N'12344232131249                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (17, N'FirstName 16                                                                                        ', N'LastName 16                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 16                                           ', N'Country 16                                                                                          ', N'1723289255                                        ', N'12344232131250                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (18, N'FirstName 17                                                                                        ', N'LastName 17                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 17                                           ', N'Country 17                                                                                          ', N'1723289256                                        ', N'12344232131251                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (19, N'FirstName 18                                                                                        ', N'LastName 18                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 18                                           ', N'Country 18                                                                                          ', N'1723289257                                        ', N'12344232131252                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (20, N'FirstName 19                                                                                        ', N'LastName 19                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 19                                           ', N'Country 19                                                                                          ', N'1723289258                                        ', N'12344232131253                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (21, N'FirstName 20                                                                                        ', N'LastName 20                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 20                                           ', N'Country 20                                                                                          ', N'1723289259                                        ', N'12344232131254                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (22, N'FirstName 21                                                                                        ', N'LastName 21                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 21                                           ', N'Country 21                                                                                          ', N'1723289260                                        ', N'12344232131255                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (23, N'FirstName 22                                                                                        ', N'LastName 22                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 22                                           ', N'Country 22                                                                                          ', N'1723289261                                        ', N'12344232131256                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (24, N'FirstName 23                                                                                        ', N'LastName 23                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 23                                           ', N'Country 23                                                                                          ', N'1723289262                                        ', N'12344232131257                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
INSERT [dbo].[PersonalInfo] ([PersonalInfoID], [FirstName], [LastName], [DateOfBirth], [City], [Country], [MobileNo], [NID], [Email], [Status]) VALUES (25, N'FirstName 24                                                                                        ', N'LastName 24                                                                                         ', CAST(N'1987-12-12 00:00:00.000' AS DateTime), N'City 24                                           ', N'Country 24                                                                                          ', N'1723289263                                        ', N'12344232131258                                                                                      ', N'dev@gmail.com                                                                                       ', 1)
GO
SET IDENTITY_INSERT [dbo].[PersonalInfo] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_PersonalInfo]    Script Date: 6/16/2018 6:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_PersonalInfo]
(
@PersonalInfoID		bigint = null,
@FirstName		nchar(100) = null,
@LastName		nchar(100) = null,
@DateOfBirth		datetime = null,
@City		nchar(50) = null,
@Country		nchar(100) = null,
@MobileNo		nchar(50) = null,
@NID		nchar(100) = null,
@Email		nchar(100) = null,
@Status		tinyint = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS



--Save PersonalInfo
if(@pOptions=1)
begin
INSERT INTO PersonalInfo
(
FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status
)
VALUES( 
@FirstName,@LastName,@DateOfBirth,@City,@Country,@MobileNo,@NID,@Email,@Status
)
IF @@ROWCOUNT = 0
Begin
SET @Msg='Warning: No rows were Inserted';	
End
Else
Begin
SET @Msg='Data Saved Successfully';	
End					
end
--End of Save PersonalInfo



--Update PersonalInfo 
if(@pOptions=2)
begin
UPDATE	PersonalInfo 
SET
FirstName	=	@FirstName ,
LastName	=	@LastName ,
DateOfBirth	=	@DateOfBirth ,
City	=	@City ,
Country	=	@Country ,
MobileNo	=	@MobileNo ,
NID	=	@NID ,
Email	=	@Email ,
Status	=	@Status 

WHERE	PersonalInfoID	=	@PersonalInfoID;
IF @@ROWCOUNT = 0
Begin
SET @Msg='Warning: No rows were Updated';	
End
Else
Begin
SET @Msg='Data Updated Successfully';
End
End
--End of Update PersonalInfo 



--Delete PersonalInfo
if(@pOptions=3)
begin
Delete from PersonalInfo Where PersonalInfoID=@PersonalInfoID;
SET @Msg='Data Deleted Successfully';
end
--End of Delete PersonalInfo 



--Select All PersonalInfo 
if(@pOptions=4)
begin	        
select * from PersonalInfo;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select All PersonalInfo 



--Select PersonalInfo By PersonalInfoID 
if(@pOptions=5)
begin
select * from PersonalInfo Where PersonalInfoID=@PersonalInfoID;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select PersonalInfo By PersonalInfoID 

GO
