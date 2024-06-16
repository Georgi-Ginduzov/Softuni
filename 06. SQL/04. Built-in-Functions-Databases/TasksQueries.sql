USE SoftUni;

--		1. Find Names of All Employees by First Name
SELECT [FirstName],[LastName]
FROM [Employees]
WHERE [FirstName] LIKE'Sa%';

--		2. Find Names of All Employees by Last Name
SELECT [FirstName],[LastName]
FROM [Employees]
WHERE [LastName] LIKE'%ei%';

--		3. Find First Names of All Employees
SELECT [FirstName]
		FROM [Employees]
		WHERE [DepartmentID] IN (3, 10) AND YEAR([HireDate]) BETWEEN 1955 AND 2005

--		4. Find All Employees Except Engineers
SELECT [FirstName]
		,[LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE'%engineer%';

--		5. Find Towns with Name Length
SELECT [Name]
		FROM Towns
		WHERE LEN([Name]) BETWEEN 5 AND 6
		ORDER BY [Name]

--		6. Find Towns Starting With
SELECT	[TownID]
		,[Name]
		FROM Towns
		WHERE LEFT(Name,1)IN ('M','K','B','E')
		ORDER BY [Name]

--		7. Find Towns Not Starting With
SELECT	[TownID]
		,[Name]
		FROM Towns
		WHERE LEFT(Name,1) NOT IN ('R','B','D')
		ORDER BY [Name]

--		8. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT	[FirstName]
		,[LastName]
		FROM [Employees]
		WHERE YEAR(HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

--		9. Length of Last Name
SELECT [FirstName]
		,[LastName]
		FROM [Employees]
		WHERE LEN([LastName]) = 5

--		10. Rank Employees by Salary
SELECT	
		[EmployeeID]
		,[FirstName]
		,[LastName]
		,[Salary]
		,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS RANK
		FROM Employees
		WHERE [Salary] BETWEEN 10000 AND 50000
		ORDER BY [Salary] DESC

--		11. Find All Employees with Rank 2
SELECT [EmployeeID]
		,[FirstName]
		,[LastName]
		,[Salary]
		,[Rank]
		FROM (
			SELECT	
				[EmployeeID]
				,[FirstName]
				,[LastName]
				,[Salary]
				,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Rank
				FROM Employees
				WHERE [Salary] BETWEEN 10000 AND 50000) AS RankedEmployeees
				WHERE Rank = 2
				ORDER BY [Salary] DESC

--		12. Countries Holding 'A' 3 or More Times
USE Geography;

SELECT [CountryName]
		,[IsoCode]
		FROM Countries