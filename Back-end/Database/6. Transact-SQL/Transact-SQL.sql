-- Problem 1.	Create a database with two tables
-- Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance). 
CREATE TABLE Persons 
(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(40),
	LastName varchar(40),
	SSN varchar(9)
)

CREATE TABLE Accounts
(
	Id int IDENTITY PRIMARY KEY,
	PersonsId int FOREIGN KEY REFERENCES Persons(Id),
	Balance money
)

-- Insert few records for testing. 

INSERT INTO Persons VALUES ('Susan', 'Summer', 555501234)
INSERT INTO Persons VALUES ('Kim', 'Mikel', 101003401)
INSERT INTO Persons VALUES ('Jimmy', 'May', 647998201)
INSERT INTO Persons VALUES ('Peter', 'Welingthon', 975234019)

INSERT INTO Accounts VALUES (1, 50000)
INSERT INTO Accounts VALUES (2, 509060)
INSERT INTO Accounts VALUES (3, 40060)
INSERT INTO Accounts VALUES (4, 2190603)

-- Write a stored procedure that selects the full names of all persons.
use [Transact-SQL]
GO

CREATE PROC usp_FullNames
AS
	SELECT FirstName + ' ' + LastName AS [Full name] FROM Persons
GO

EXEC usp_FullNames

-- Problem 2.	Create a stored procedure
-- Your task is to create a stored procedure that accepts a number as a parameter and 
-- returns all persons who have more money in their accounts than the supplied number.
use [Transact-SQL]
GO

CREATE PROC usp_Money
AS
	SELECT FirstName + ' ' + LastName AS [Full name], a.Balance FROM Persons p
	INNER JOIN Accounts a ON p.Id = a.PersonsId 
	WHERE a.Balance > 100000
GO

EXEC usp_Money

-- Problem 3.	Create a function with parameters
-- Your task is to create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
use [Transact-SQL]
GO

CREATE FUNCTION ufn_Interest(@sum money, @rate real, @numberOfMonths int) RETURNS real
AS
BEGIN
	DECLARE @calc real;
	SET @calc =  @sum * (1 + ((@rate / 100)  * @numberOfMonths))
	RETURN @calc
END
GO

SELECT dbo.ufn_Interest(10000, 10, 12) AS 'Calculate rate'

-- Problem 4.	Create a stored procedure that uses the function from the previous example.
-- Your task is to create a stored procedure that uses the function from the previous example 
-- to give an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.
USE [Transact-SQL]
GO

CREATE PROCEDURE usp_InterestPerMonth(@accountId int, @rate real)
AS
	DECLARE @currentBalance money
	SELECT @currentBalance = Balance FROM Accounts a 
	WHERE a.Id = @accountId
	
	DECLARE @newBalance money
	SELECT  @newBalance = dbo.ufn_Interest(@currentBalance, @rate, 1)

	SELECT p.FirstName, p.LastName, a.Balance, @newBalance AS NewBalance FROM Persons p
    INNER JOIN Accounts a ON p.Id = a.PersonsId
    WHERE a.Id = @accountId

GO

EXEC usp_InterestPerMonth 1, 2
EXEC usp_InterestPerMonth 2, 4

-- Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney.
-- Add two more stored procedures WithdrawMoney (AccountId, money) 
-- and DepositMoney (AccountId, money) that operate in transactions.
USE [Transact-SQL]
GO

CREATE PROC usp_WithdrawMoney(@accountId int, @money money)
AS
	DECLARE @currentBalance money
	SELECT @currentBalance = Balance FROM Accounts a
	WHERE a.Id = @accountId

	DECLARE @balanceAfterWithdraw money
	SELECT @balanceAfterWithdraw = @currentBalance - @money

	SELECT p.FirstName, p.LastName, a.Balance, @balanceAfterWithdraw AS BalanceAfterWithdraw FROM Persons p
	INNER JOIN Accounts a ON p.Id = a.PersonsId
	WHERE a.Id = @accountId
GO

EXEC usp_WithdrawMoney 3, 15000

USE [Transact-SQL]
GO

CREATE PROC usp_DepositMoney(@accountId int, @money money)
AS
	DECLARE @currentBalance money
	SELECT @currentBalance = Balance FROM Accounts a
	WHERE a.Id = @accountId

	DECLARE @balanceAfterDeposit money
	SELECT @balanceAfterDeposit = @currentBalance + @money

	SELECT p.FirstName, p.LastName, a.Balance, @balanceAfterDeposit AS BalanceAfterDeposit FROM Persons p
	INNER JOIN Accounts a ON p.Id = a.PersonsId
	WHERE a.Id = @accountId
GO

EXEC usp_DepositMoney 4, 234000

-- Problem 6.	Create table Logs.
-- Create another table – Logs (LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs
(
	LogID int IDENTITY,
	AccountID int FOREIGN KEY REFERENCES Accounts(Id),
	OldSum money,
	NewSum money
)

USE [Transact-SQL]
GO

CREATE TRIGGER tr_AccountsLog ON Accounts FOR UPDATE
AS
	DECLARE @accountId int
	DECLARE @oldSum money
	DECLARE @newSum money

	SELECT @accountId = i.Id FROM inserted i
	SELECT @oldSum = d.Balance FROM deleted d
	SELECT @newSum = i.Balance FROM inserted i


	INSERT INTO Logs
	VALUES (@accountId, @oldSum, @newSum)
GO

UPDATE Accounts
SET Balance = 300000
WHERE Id = 1

UPDATE Accounts
SET Balance = 13300000
WHERE Id = 2

SELECT p.FirstName, l.AccountID, l.OldSum, l.NewSum FROM Logs l
INNER JOIN Persons p ON p.Id = l.AccountID

-- Problem 7.	Define function in the SoftUni database.
-- Define a function in the database SoftUni that returns all Employee's names (first or middle or last name) 
-- and all town's names that are comprised of given set of letters. 
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', but not 'Rob' and 'Guy'.
USE SoftUni
GO

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

CREATE ASSEMBLY SqlRegularExpressions 
FROM 'C:\Users\Tushe.Tushe-PC\Desktop\SqlRegularExpressions.dll'
GO

CREATE FUNCTION RegExpLike(@input nvarchar(MAX), @pattern nvarchar(MAX)) RETURNS bit
AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[Like]


CREATE FUNCTION ufn_DisplayNamesAndTowns(@pattern varchar(MAX)) RETURNS @Matches TABLE (Name varchar(50))
AS
BEGIN
INSERT INTO @Matches
	SELECT * FROM (
		SELECT FirstName FROM Employees
		UNION
		SELECT LastName FROM Employees
		UNION
		SELECT Name FROM Towns) as temp(name)
	WHERE 1 = dbo.RegExpLike(LOWER(Name), @pattern)
	RETURN
END
GO

SELECT * FROM ufn_DisplayNamesAndTowns('^[oistmiahf]+')



-- Problem 8.	Using database cursor write a T-SQL
-- Using database cursor write a T-SQL script that scans all employees and 
-- their addresses and prints all pairs of employees that live in the same town.

DECLARE empCursor CURSOR READ_ONLY FOR
        SELECT 
			e.FirstName, 
			e.LastName, 
			t.Name,
			em.FirstName, 
			em.LastName
        FROM Employees e
                INNER JOIN Addresses a
                        ON a.AddressID = e.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees em
                INNER JOIN Addresses ad
                        ON ad.AddressID = em.AddressID
                INNER JOIN Towns tw
                        ON tw.TownID = ad.TownID               
 
        OPEN empCursor
        DECLARE @firstName NVARCHAR(50)
        DECLARE @lastName NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
        DECLARE @firstNamePair NVARCHAR(50)
        DECLARE @lastNamePair NVARCHAR(50)
        FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town, @firstNamePair, @lastNamePair
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
					PRINT @firstName + ' ' + @lastName + '   ' + @town + '   ' + @firstNamePair + ' ' + @lastNamePair
                    FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town, @firstNamePair, @lastNamePair
                END
 
        CLOSE empCursor
		DEALLOCATE empCursor

-- Problem 9.	Define a .NET aggregate function
-- Define a .NET aggregate function StrConcat that takes as input a sequence 
-- of strings and return a single string that consists of the input strings separated by ','. 
USE SoftUni
GO

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

CREATE ASSEMBLY SqlStrConcAssembly
FROM 'C:\SQLStrConc.dll'  --change the path to SQLStrConc.dll
WITH PERMISSION_SET = SAFE
GO

CREATE AGGREGATE dbo.StrConcat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(MAX) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL NAME SqlStrConcAssembly.concat; 
GO 

SELECT dbo.StrConcat(FirstName + ' ' + LastName, ', ') AS 'Full name' FROM Employees