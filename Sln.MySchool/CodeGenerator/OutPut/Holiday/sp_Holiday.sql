SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Holiday]
(
@SL		bigint = null,
@HolidayStartDate		datetime = null,
@HolidayEndDate		datetime = null,
@Notes		nvarchar(350) = null,
@Status		tinyint = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS



--Save Holiday
if(@pOptions=1)
begin
INSERT INTO Holiday
(
HolidayStartDate,HolidayEndDate,Notes,Status
)
VALUES( 
@SL,@HolidayStartDate,@HolidayEndDate,@Notes,@Status
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
--End of Save Holiday



--Update Holiday 
if(@pOptions=2)
begin
UPDATE	Holiday 
SET
HolidayStartDate	=	@HolidayStartDate ,
HolidayEndDate	=	@HolidayEndDate ,
Notes	=	@Notes ,
Status	=	@Status 

WHERE	SL	=	@SL;
IF @@ROWCOUNT = 0
Begin
SET @Msg='Warning: No rows were Updated';	
End
Else
Begin
SET @Msg='Data Updated Successfully';
End
End
--End of Update Holiday 



--Delete Holiday
if(@pOptions=3)
begin
Delete from Holiday Where SL=@SL;
SET @Msg='Data Deleted Successfully';
end
--End of Delete Holiday 



--Select All Holiday 
if(@pOptions=4)
begin	        
select * from Holiday;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select All Holiday 



--Select Holiday By SL 
if(@pOptions=5)
begin
select * from Holiday Where SL=@SL;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Holiday By SL 
