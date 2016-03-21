use SoftUni
GO

-- Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
-- Use a nested SELECT statement.
SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- Problem 2.	Write a SQL query to find the names and salaries of the employees 
-- that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary < (SELECT MIN((Salary * 0.1) + Salary) FROM Employees) 

-- Problem 3.	Write a SQL query to find the full name, salary and department of the employees 
-- that take the minimal salary in their department.
SELECT e.FirstName, e.LastName, e.Salary, d.Name AS DepName FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)

-- Problem 4.	Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Department AVG Salary] FROM Employees
	WHERE DepartmentID = 1

-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name AS [Department], AVG(e.Salary) AS [Average Salary] FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name

-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS 'Number of employees' FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

-- Problem 7.	Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) AS [Employees with manager] FROM Employees

-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) - COUNT(ManagerID) AS [Employees without manager] FROM Employees

-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS 'Department', AVG(e.Salary) AS 'Average Salary' FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name

-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS 'Town', d.Name AS 'Department', COUNT(*) AS 'Employees count' FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a ON e.AddressID = a.AddressID
	INNER JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name, d.Name

-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
-- Display their first name and last name.
SELECT m.FirstName, m.LastName,  COUNT(e.ManagerID) AS 'Employees count' FROM Employees e
	INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(e.ManagerID) = 5

-- Problem 12.	Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName, e.LastName, ISNULL (m.FirstName + ' ' + m.LastName, 'No manager') AS Manager FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

-- Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
-- Use the built-in LEN(str) function.
SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5

-- Problem 14.	Write a SQL query to display the current date and time in the following format 
-- "day.month.year hour:minutes:seconds:milliseconds". 
SELECT CONVERT(varchar, GETDATE(), 113) AS 'Current date and time'

-- Problem 15.	Write a SQL statement to create a table Users.
CREATE TABLE Users (
	Id int IDENTITY,
	Username nvarchar(20),
	Password nvarchar(20),
	FullName nvarchar(50),
	LastLoginTime datetime,
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT Username UNIQUE(Username),
	CONSTRAINT Check_password_lenght CHECK(LEN(Password) >=5)
)

SELECT * FROM Users

-- Problem 16.	Write a SQL statement to create a view that displays the users from the 
-- Users table that have been in the system today.
CREATE VIEW [Current user] AS 
SELECT * FROM Users

SELECT * FROM [Current user]

-- Problem 17.	Write a SQL statement to create a table Groups.
-- Groups should have unique name (use unique constraint). Define primary key and identity column.
CREATE TABLE Groups (
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(50) UNIQUE
)

-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
-- Fill some data in this new column and as well in the Groups table. Write a SQL statement to add 
-- a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
ADD GroupID int 

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID) REFERENCES Groups(Id)

-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users 
	VALUES ('todor_p', 'strv12', 'Todor Petrovich', GETDATE(), 1),
			('petar', 'ppppp23', 'Petar V', GETDATE(), 2),
			('ivan', '12345', 'Ivan Ivanov', GETDATE(), NULL)
INSERT INTO Groups
	VALUES ('Sport'), ('Eating'), ('Humor')

SELECT u.Username, g.Name FROM Users u
INNER JOIN Groups g ON u.GroupID = g.Id

-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Password = '12345'
WHERE Username = 'todor_p'

SELECT * FROM Users

UPDATE Groups
SET Name = 'Happy'
WHERE Name = 'Eating'

SELECT * FROM Groups

-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'ivan_iv'

SELECT * FROM Users

DELETE FROM Groups
WHERE Name = 'Humor'

SELECT * FROM Groups

-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time.

INSERT INTO Users (FullName, Username, Password)
	SELECT (FirstName + ' ' + LastName),
		(SUBSTRING(FirstName, 1, 3) + LOWER(LastName)),			
		(CASE WHEN LEN(LOWER(SUBSTRING(FirstName, 1, 1) + '_' + LastName)) > 4
			THEN LOWER(SUBSTRING(FirstName, 0, 2) + '_' + LastName)
			ELSE '12345'
			END)
	FROM Employees

SELECT * FROM Users

-- Problem 23.	Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users SET LastLoginTime = '10-02-2010'

UPDATE Users SET Password = NULL
	WHERE DATEDIFF(DAY, LastLoginTime, CAST('10-03-2010' AS date)) > 0

-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).
UPDATE Users SET Password = '12345'
	WHERE Username = 'Kevbrown'

DELETE FROM Users
	WHERE Password IS NULL

-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(Salary) AS [Avarege Salary] FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- Problem 26.	Write a SQL query to display the minimal employee salary by department 
-- and job title along with the name of some of the employees that take it.
SELECT d.Name, e.JobTitle, e.FirstName, MIN(e.Salary) AS 'Min salary' FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName

-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Number of employees] FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

-- Problem 28.	Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(e.EmployeeID) AS 'Number of managers' FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
WHERE e.EmployeeID IN (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name 

-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
-- Each employee should have id, date, task, hours and comments. Don't forget to define identity, primary key and appropriate foreign key.

CREATE TABLE WorkHours 
(
	EmpId int IDENTITY PRIMARY KEY,
	EmpDate datetime,
	EmpTask varchar(40),
	EmpHours int,
	EmpComments varchar(MAX),
	EmployeesID int FOREIGN KEY REFERENCES Employees(EmployeeID)
);

-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours VALUES (GETDATE(), 'Selling', 30, 'No comments', 1);
INSERT INTO WorkHours VALUES (GETDATE(), 'Logistic', 45, 'No comments', 23);
INSERT INTO WorkHours VALUES (GETDATE(), 'Managing', 44, 'Need more practice', 35);

UPDATE WorkHours 
SET EmpHours = 48
WHERE EmpTask = 'Logistic'

UPDATE WorkHours 
SET EmpComments = 'Good job'
WHERE EmpTask = 'Selling'

delete from WorkHours

DELETE FROM WorkHours
	WHERE EmpTask = 'Selling'

SELECT * FROM WorkHours

-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHoursLogs 
(
	EmpId int,
	EmpDate datetime,
	EmpTask varchar (40),
	EmpHours int,
	EmpComments varchar(100),
	EmployeesID int FOREIGN KEY REFERENCES Employees(EmployeeID),
	Audite_action varchar(50),
	Audite_time datetime
)

-- insert
USE SoftUni
GO

CREATE TRIGGER tr_AfterInsert ON WorkHours FOR INSERT
AS
	declare @empid int;
	declare @empdate datetime;
	declare @emptask varchar(40);
	declare @emphours int;
	declare @empcommnets varchar(100);
	declare @emp_id_date int;
	declare @audit_action varchar(50);

	select @empid=i.EmpId from inserted i;
	select @empdate = i.EmpDate from inserted i;
	select @emptask = i.EmpTask from inserted i;
	select @emphours = i.EmpHours from inserted i;
	select @empcommnets = i.EmpComments from inserted i;
	select @emp_id_date = i.EmployeesID from inserted i;
	set @audit_action = 'Inserted Record -- After Insert Trigger.';

	insert into WorkHoursLogs
	values (@empid, @empdate, @emptask, @emphours, @empcommnets, @emp_id_date, @audit_action, GETDATE())

	PRINT 'AFTER INSERT trigger fired.'

GO

--update

CREATE TRIGGER tr_AfterUpdate ON WorkHours FOR UPDATE
AS
	declare @empid int;
	declare @empdate datetime;
	declare @emptask varchar(40);
	declare @emphours int;
	declare @empcommnets varchar(100);
	declare @emp_id_date int;
	declare @audit_action varchar(50);

	select @empid=i.EmpId from inserted i;
	select @empdate = i.EmpDate from inserted i;
	select @emptask = i.EmpTask from inserted i;
	select @emphours = i.EmpHours from inserted i;
	select @empcommnets = i.EmpComments from inserted i;
	select @emp_id_date = i.EmployeesID from inserted i;
	set @audit_action = 'Updated Record -- After Update Trigger.';

	insert into WorkHoursLogs
	values (@empid, @empdate, @emptask, @emphours, @empcommnets, @emp_id_date, @audit_action, GETDATE())

	PRINT 'AFTER UPDATE trigger fired.'

GO

-- delete

CREATE TRIGGER tr_AfterDelete ON WorkHours FOR DELETE
AS
	declare @empid int;
	declare @empdate datetime;
	declare @emptask varchar(40);
	declare @emphours int;
	declare @empcommnets varchar(100);
	declare @emp_id_date int;
	declare @audit_action varchar(50);

	select @empid=d.EmpId from deleted d;
	select @empdate = d.EmpDate from deleted d;
	select @emptask = d.EmpTask from deleted d;
	select @emphours = d.EmpHours from deleted d;
	select @empcommnets = d.EmpComments from deleted d;
	select @emp_id_date = d.EmployeesID from deleted d;
	set @audit_action = 'Deleted Record -- After Delete Trigger.';

	insert into WorkHoursLogs
	values (@empid, @empdate, @emptask, @emphours, @empcommnets, @emp_id_date, @audit_action, GETDATE())

	PRINT 'AFTER DELETE trigger fired.'

GO

select * from WorkHoursLogs

-- Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. 
-- At the end rollback the transaction.

BEGIN TRAN
ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Departments
ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees
DELETE FROM Departments
	WHERE Name = 'Sales'
ROLLBACK TRAN

SELECT * FROM Departments

-- Problem 33.	Start a database transaction and drop the table EmployeesProjects.
-- Then how you could restore back the lost table data?

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

-- Problem 34.	Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
CREATE TABLE #Temp
(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
	PRIMARY KEY (EmployeeID, ProjectID)
)

INSERT INTO #Temp 
SELECT * FROM EmployeesProjects

SELECT * FROM #Temp

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects 
(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
	PRIMARY KEY (EmployeeID, ProjectID)
)

INSERT INTO EmployeesProjects
SELECT * FROM #Temp

SELECT * FROM EmployeesProjects

DROP TABLE #Temp

