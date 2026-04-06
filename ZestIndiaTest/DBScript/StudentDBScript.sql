--CREATE DATABASE StudentDB

--CREATE TABLE Students(
--Id INT IDENTITY(1,1) PRIMARY KEY,
--Name NVARCHAR(100),
--Email NVARCHAR(100),
--Age INT,
--Course NVARCHAR(100),
--CreatedDate DATETIME,
--ModifiedDate DateTime,
--CreatedBy NVARCHAR(100),
--ModifiedBy NVARCHAR(100)
--);


--CREATE PROCEDURE InsertNewStudent
--    @Name NVARCHAR(100),
--    @Email NVARCHAR(100),
--    @Age INT,
--    @Course NVARCHAR(100),
--	@CreatedBy NVARCHAR(100)
--AS
--BEGIN
--    INSERT INTO Students (Name, Email, Age, Course, CreatedDate, CreatedBy)
--    VALUES (@Name, @Email, @Age, @Course,GETDATE(), @CreatedBy )
--END



--CREATE PROCEDURE UpdateStudent
--    @Id INT,
--    @Name NVARCHAR(100),
--    @Email NVARCHAR(100),
--    @Age INT,
--    @Course NVARCHAR(100),
--	@ModifiedBy NVARCHAR(100)
--AS
--BEGIN
--    UPDATE Students
--    SET  Name = @Name, Email = @Email,  Age = @Age, Course = @Course,
--		ModifiedBy = @ModifiedBy, ModifiedDate = GETDATE()
--    WHERE Id = @Id
--END


--CREATE PROCEDURE DeleteStudent
--    @Id INT
--AS
--BEGIN
--    DELETE FROM Students
--    WHERE Id = @Id
--END

--CREATE PROCEDURE GetAllStudents
--AS
--BEGIN
--    SELECT * FROM Students
--END