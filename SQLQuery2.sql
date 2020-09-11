CREATE PROC UserViewByID1
@UserID int
as 
  select *
  FROM StudentRegistration
  WHERE UserID=@UserID