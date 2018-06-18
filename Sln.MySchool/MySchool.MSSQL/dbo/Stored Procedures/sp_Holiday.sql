
CREATE PROC [dbo].[sp_Holiday] (@SL bigint = NULL,
@HolidayStartDate datetime = NULL,
@HolidayEndDate datetime = NULL,
@Notes		nvarchar(350) = null,
@Status tinyint = NULL,

@Msg nvarchar(max) = NULL OUT,
@pOptions int)
AS



  --Save Holiday
  IF (@pOptions = 1)
  BEGIN
    INSERT INTO Holiday (HolidayStartDate, HolidayEndDate, Notes, Status)
      VALUES (@HolidayStartDate, @HolidayEndDate, @Notes, @Status)
    IF @@ROWCOUNT = 0
    BEGIN
      SET @Msg = 'Warning: No rows were Inserted';
    END
    ELSE
    BEGIN
      SET @Msg = 'Data Saved Successfully';
    END
  END
  --End of Save Holiday



  --Update Holiday 
  IF (@pOptions = 2)
  BEGIN
    UPDATE Holiday
    SET HolidayStartDate = @HolidayStartDate,
        HolidayEndDate = @HolidayEndDate,
        Notes = @Notes,
        Status = @Status

    WHERE SL = @SL;
    IF @@ROWCOUNT = 0
    BEGIN
      SET @Msg = 'Warning: No rows were Updated';
    END
    ELSE
    BEGIN
      SET @Msg = 'Data Updated Successfully';
    END
  END
  --End of Update Holiday 



  --Delete Holiday
  IF (@pOptions = 3)
  BEGIN
    DELETE FROM Holiday
    WHERE SL = @SL;
    SET @Msg = 'Data Deleted Successfully';
  END
  --End of Delete Holiday 



  --Select All Holiday 
  IF (@pOptions = 4)
  BEGIN
    SELECT
      *
    FROM Holiday;
    IF (@@ROWCOUNT = 0)
      SET @Msg = 'Data Not Found';
  END
  --End of Select All Holiday 



  --Select Holiday By SL 
  IF (@pOptions = 5)
  BEGIN
    SELECT
      *
    FROM Holiday
    WHERE SL = @SL;
    IF (@@ROWCOUNT = 0)
      SET @Msg = 'Data Not Found';
  END
--End of Select Holiday By SL 