-- Problem 1.	Create a table in SQL Server
USE SoftUni
GO
CREATE TABLE MillionsOfEmployees
(
	ID int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	JobTitle nvarchar(50),
	DepartmentID int FOREIGN KEY REFERENCES Departments(DepartmentID),
	HireDate smalldatetime
)
-- inser data into the table - use transaction for faster insertion
BEGIN TRAN
DECLARE @i int
SET @i = 0
WHILE (@i < 34130)
BEGIN
	INSERT INTO MillionsOfEmployees(FirstName, LastName, JobTitle, DepartmentID, HireDate)
	SELECT FirstName, LastName, JobTitle, DepartmentID, HireDate FROM Employees
	SET @i = @i + 1
END
COMMIT TRAN

-- clean cache
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
GO

SELECT m.FirstName, d.Name, m.HireDate FROM MillionsOfEmployees m -- Time: 16 sec.
INNER JOIN Departments d ON m.DepartmentID = d.DepartmentID
WHERE FirstName LIKE 'S%'
ORDER BY HireDate

-- Problem 2.	Add an index to speed-up the search by date 

-- create index to speed up the firstname
CREATE INDEX SpeedUp 
ON MillionsOfEmployees(FirstName) -- It took 20 sec. to create the index

SELECT FirstName FROM MillionsOfEmployees -- It took 45 sec with Index. The time without Index was 54 sec.

DROP INDEX SpeedUp ON MillionsOfEmployees

-- create index to speed up the first and last name

CREATE INDEX SpeedUpFisrstAndLastName 
ON MillionsOfEmployees(FirstName, LastName) -- It took 1:19 to create the index

SELECT FirstName, LastName FROM MillionsOfEmployees -- It took 52 sec with Index. The time without Index was 1:04.

DROP INDEX SpeedUpFisrstAndLastName ON MillionsOfEmployees

-- create index on all columns

CREATE INDEX SpeedUpAll
ON MillionsOfEmployees(FirstName, LastName, JobTitle, DepartmentID, HireDate) -- Time 2:14

SELECT * FROM MillionsOfEmployees -- 1:21 with index vs 1:25 without index.

SELECT FirstName, LastName, JobTitle, DepartmentID, HireDate FROM MillionsOfEmployees -- Time: 1:18

-- WHERE
SELECT * FROM MillionsOfEmployees -- Time: 8 sec. vs 15 sec
WHERE FirstName LIKE 'S%'

SELECT m.FirstName, d.Name, m.HireDate FROM MillionsOfEmployees m -- Time: 8 sec vs 15 sec
INNER JOIN Departments d ON d.DepartmentID = m.DepartmentID
WHERE FirstName LIKE 'S%'
ORDER BY HireDate

DROP INDEX SpeedUpAll ON MillionsOfEmployees

DROP TABLE MillionsOfEmployees