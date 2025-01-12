-- Get all employee
CREATE PROCEDURE [dbo].[spGetAllEmployees]
AS
BEGIN
	SELECT * FROM Employee
END


-- Insert an employee
CREATE PROCEDURE spInsertEmployee
@name varchar(50),
@gender varchar(10),
@age int,
@city varchar(50)
AS
BEGIN
	INSERT INTO Employee values(@name,@gender,@age,@city)
END


-- Update an employee
CREATE PROCEDURE spUpdateEmployee
@id int,
@name varchar(50),
@gender varchar(10),
@age int,
@city varchar(50)
AS
BEGIN
	UPDATE Employee set [Name] = @name,[Gender] = @gender, [Age] = @age, [City] = @city WHERE [Id] = @id;
END


-- Delete an employee
CREATE PROCEDURE spDeleteEmployee
@id int
AS
BEGIN
	DELETE FROM Employee WHERE [Id] = @id
END