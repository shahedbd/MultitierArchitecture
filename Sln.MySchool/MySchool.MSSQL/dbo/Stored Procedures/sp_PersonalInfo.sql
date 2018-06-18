
CREATE PROC [dbo].[sp_PersonalInfo] (@PersonalInfoID bigint = NULL,
@FirstName nchar(100) = NULL,
@LastName nchar(100) = NULL,
@DateOfBirth datetime = NULL,
@City nchar(50) = NULL,
@Country nchar(100) = NULL,
@MobileNo nchar(50) = NULL,
@NID nchar(100) = NULL,
@Email nchar(100) = NULL,
@Status tinyint = NULL,

@Msg nvarchar(max) = NULL OUT,
@pOptions int)
AS



  --Save PersonalInfo
  IF (@pOptions = 1)
  BEGIN
    INSERT INTO PersonalInfo (FirstName, LastName, DateOfBirth, City, Country, MobileNo, NID, Email, Status)
      VALUES (@FirstName, @LastName, @DateOfBirth, @City, @Country, @MobileNo, @NID, @Email, @Status)
    IF @@ROWCOUNT = 0
    BEGIN
      SET @Msg = 'Warning: No rows were Inserted';
    END
    ELSE
    BEGIN
      SET @Msg = 'Data Saved Successfully';
    END
  END
  --End of Save PersonalInfo



  --Update PersonalInfo 
  IF (@pOptions = 2)
  BEGIN
    UPDATE PersonalInfo
    SET FirstName = @FirstName,
        LastName = @LastName,
        DateOfBirth = @DateOfBirth,
        City = @City,
        Country = @Country,
        MobileNo = @MobileNo,
        NID = @NID,
        Email = @Email,
        Status = @Status

    WHERE PersonalInfoID = @PersonalInfoID;
    IF @@ROWCOUNT = 0
    BEGIN
      SET @Msg = 'Warning: No rows were Updated';
    END
    ELSE
    BEGIN
      SET @Msg = 'Data Updated Successfully';
    END
  END
  --End of Update PersonalInfo 



  --Delete PersonalInfo
  IF (@pOptions = 3)
  BEGIN
    DELETE FROM PersonalInfo
    WHERE PersonalInfoID = @PersonalInfoID;
    SET @Msg = 'Data Deleted Successfully';
  END
  --End of Delete PersonalInfo 



  --Select All PersonalInfo 
  IF (@pOptions = 4)
  BEGIN
    SELECT
      *
    FROM PersonalInfo;
    IF (@@ROWCOUNT = 0)
      SET @Msg = 'Data Not Found';
  END
  --End of Select All PersonalInfo 



  --Select PersonalInfo By PersonalInfoID 
  IF (@pOptions = 5)
  BEGIN
    SELECT
      *
    FROM PersonalInfo
    WHERE PersonalInfoID = @PersonalInfoID;
    IF (@@ROWCOUNT = 0)
      SET @Msg = 'Data Not Found';
  END
--End of Select PersonalInfo By PersonalInfoID 

  --Select ***
  IF (@pOptions = 6)
  BEGIN
    SELECT
      *
    FROM PersonalInfo
    WHERE PersonalInfoID = @PersonalInfoID;
    IF (@@ROWCOUNT = 0)
      SET @Msg = 'Data Not Found';
  END
--End of Select ***