CREATE PROC UserAddOrEdit
@UserID int,
@FirstName varchar(50),
@LastName varchar(50),
@Contact varchar(10),
@Gender varchar(10),
@Address varchar(250),
@Education varchar(50),
@Course varchar(50),
@EmailId varchar(50),
@Passingyear varchar(50),
@DateofBirth varchar(50),
@Username varchar(50),
@Password varbinary(50)
AS
    IF @UserID= 0
    BEGIN
	   INSERT INTO StudentRegistration ( FirstName,LastName,Contact,Gender,Address,Education,Course,EmailId,Passingyear,DateofBirth,Username,Password)
	   VALUES ( @FirstName,@LastName,@Contact,@Gender,@Address,@Education,@Course,@EmailId,@Passingyear,@DateofBirth,@Username,@Password)

 END 
 ELSE
 BEGIN
 UPDATE StudentRegistration
 SET
      FirstName=@FirstName, 
      LastName=@LastName,
      Contact=@Contact,
      Address=@Address,
      Education=@Education,
      Course =@Course,
     EmailId =@EmailID,
      Passingyear =@Passingyear,
      DateOfBirth= @DateofBirth,
      Username =@Username,
      Password =@Password
      WHERE UserID=@UserID

 END

