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
