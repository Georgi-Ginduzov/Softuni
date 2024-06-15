--		Create Database
CREATE DATABASE Relations

USE Relations;

-- 1. One-To-One Relationship
--		Create Tables

CREATE TABLE Persons 
(
	ID INT,
	FirstName VARCHAR(30),
	Salary DECIMAL(7, 2),
	PassportID INT
)

SELECT * FROM Persons

CREATE TABLE Passports
(
	PassportID INT,
	PassportNumber VARCHAR(30)
)

SELECT * FROM Passports

--		Insert Data in Tables

INSERT INTO Persons ([ID], [FirstName], [Salary], [PassportID])
		VALUES (1, 'Roberto', 43300.00, 102)
				,(2, 'Tom', 56100.00, 103)
				,(3, 'Yana', 60200.00, 101)

SELECT * FROM Persons

INSERT INTO Passports ([PassportID], [PassportNumber])
				VALUES (101, 'N34FG21B')
						,(102, 'K65LO4R7')
						,(103, 'ZE657QP2')

--		Set Primary key

ALTER TABLE Persons
ALTER COLUMN ID INT NOT NULL

ALTER TABLE Persons
ADD PRIMARY KEY (ID)

--		Add Foreign Key between both Tables

ALTER TABLE Passports
ALTER COLUMN PassportID INT NOT NULL

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID)
REFERENCES Passports (PassportID)



-- 2. One-To-Many Relationship

--		Create Tables
CREATE TABLE Models
(
	ModelID INT NOT NULL,
	Name VARCHAR(30),
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT NOT NULL
	, Name VARCHAR(30)
	, EstablishedOn DATE
)

SELECT * FROM Models
SELECT * FROM Manufacturers

--		Insert Data
INSERT INTO Manufacturers ([ManufacturerID], [Name], [EstablishedOn])
					VALUES(1, 'BMW', '1916-03-07')
							, (2, 'Tesla', '2003-01-01')
							, (3, 'Lada', '1966-05-01')

INSERT INTO Models ([ModelID], [Name], [ManufacturerID])
			VALUES (101, 'X1', 1)
					, (102, 'i6', 1)
					, (103, 'Model S', 2)
					, (104, 'Model X', 2)
					, (105, 'Model 3', 2)
					, (106, 'Nova', 3)

--		Add Primary Keys
ALTER TABLE Models
ADD PRIMARY KEY ([ModelID])

ALTER TABLE Manufacturers
ADD PRIMARY KEY ([ManufacturerID])

--		Add Foreign Key
ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturer FOREIGN KEY ([ManufacturerID])
REFERENCES Manufacturers(ManufacturerID)

-- 3. Many-To-Many Relationship
--		Create Tables
CREATE TABLE Students 
(
	StudentID INT,
	Name VARCHAR(30)
)

CREATE TABLE Exams
(
	ExamID INT,
	Name VARCHAR(30)
)

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT
)

SELECT * FROM Students 
SELECT * FROM Exams
SELECT * FROM StudentsExams

--		Insert Data
INSERT INTO Students ([StudentID], [Name])
				VALUES (1, 'Mila')
						,(2, 'Toni')
						,(3, 'Ron')

INSERT INTO Exams ([ExamID], [Name])
			VALUES(101, 'SpringMVC')
					,(102, 'Neo4j')
					,(103, 'Oracle 11g')

INSERT INTO StudentsExams([StudentID], [ExamID])
			VALUES(1, 101)
				,(2, 102)
				,(3, 101)

--		ADD PRIMARY KEYS
ALTER TABLE Students
ALTER COLUMN [StudentID] INT NOT NULL

ALTER TABLE Exams
ALTER COLUMN [ExamID] INT NOT NULL

ALTER TABLE Students
ADD PRIMARY KEY([StudentID])

ALTER TABLE Exams
ADD PRIMARY KEY([ExamID])

ALTER TABLE StudentsExams
ALTER COLUMN [StudentID] INT NOT NULL
ALTER TABLE StudentsExams
ALTER COLUMN [ExamID] INT NOT NULL

ALTER TABLE StudentsExams
ADD PRIMARY KEY([StudentID], [ExamID])
-- ADD FOREIGN KEYS
ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Students_StudentsExams FOREIGN KEY ([StudentID])
REFERENCES Students([StudentID])

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Exams_StudentsExams FOREIGN KEY ([ExamID])
REFERENCES Exams([ExamID])


-- 4. Self-Referencing
--		CREATE TABLE
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	ManagerID INT REFERENCES Teachers([TeacherID])
)

-- 5. Online Store Database
CREATE DATABASE OnlineStore

USE OnlineStore;

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY,
	Name VARCHAR(30)
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY,
	Name VARCHAR(30),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities 
(
	CityID INT PRIMARY KEY,
	Name VARCHAR(30)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY,
	Name VARCHAR(30),
	Birthday DATE, 
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE ORDERS
(
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items (ItemID),
	CONSTRAINT pk_orderitems PRIMARY KEY (OrderID, ItemID)
)

-- 6. University Database
CREATE DATABASE University

USE University;

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	[Name] NVARCHAR(32) 
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY,
	SubjectName NVARCHAR(100) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber VARCHAR(64) NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL(10, 2)  NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)


-- 9. Peaks in Rila
USE Geography;

SELECT [Mountains].[MountainRange]
		, [Peaks].[PeakName]
		, [Peaks].[Elevation]
		FROM Peaks 
		JOIN Mountains ON [Peaks].[MountainId] = [Mountains].[Id]
		WHERE [MountainRange] = 'Rila'
		ORDER BY [Elevation] DESC