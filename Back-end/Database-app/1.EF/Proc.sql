USE SoftUni
GO

CREATE PROC usp_find_projects(@firsName nvarchar(50), @lastName nvarchar(50))
AS
	SELECT p.Name AS ProjetcName, p.Description, p.StartDate FROM Projects p
		JOIN EmployeesProjects ep ON ep.ProjectID = p.ProjectID
		JOIN Employees e ON e.EmployeeID = ep.EmployeeID
	WHERE e.FirstName = @firsName AND e.LastName = @lastName
GO

exec usp_find_projects 'JoLynn', 'Dobney'