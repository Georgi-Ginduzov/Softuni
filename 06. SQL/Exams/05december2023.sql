-- Create RailwaysDb database
CREATE DATABASE RailwaysDb;
GO

-- Use the RailwaysDb database
USE RailwaysDb;
GO

-- Create the Passengers table
CREATE TABLE Passengers (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    Name NVARCHAR(80) NOT NULL         -- Passenger name, non-null
);

-- Create the Towns table
CREATE TABLE Towns (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    Name VARCHAR(30) NOT NULL         -- Town name, non-null
);

-- Create the RailwayStations table
CREATE TABLE RailwayStations (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    Name VARCHAR(50) NOT NULL,        -- Railway station name, non-null
    TownId INT NOT NULL,               -- Foreign key reference to Towns
    FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

-- Create the Trains table
CREATE TABLE Trains (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    HourOfDeparture VARCHAR(5) NOT NULL,  -- Hour of departure, non-null
    HourOfArrival VARCHAR(5) NOT NULL,    -- Hour of arrival, non-null
    DepartureTownId INT NOT NULL,          -- Foreign key reference to Towns (departure)
    ArrivalTownId INT NOT NULL,            -- Foreign key reference to Towns (arrival)
    FOREIGN KEY (DepartureTownId) REFERENCES Towns(Id),
    FOREIGN KEY (ArrivalTownId) REFERENCES Towns(Id)
);

-- Create the TrainsRailwayStations table
CREATE TABLE TrainsRailwayStations (
    TrainId INT NOT NULL,              -- Foreign key reference to Trains
    RailwayStationId INT NOT NULL,     -- Foreign key reference to RailwayStations
    PRIMARY KEY (TrainId, RailwayStationId),  -- Composite primary key
    FOREIGN KEY (TrainId) REFERENCES Trains(Id),
    FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)
);

-- Create the MaintenanceRecords table
CREATE TABLE MaintenanceRecords (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    DateOfMaintenance DATE NOT NULL,   -- Date of maintenance, non-null
    Details VARCHAR(2000) NOT NULL,   -- Maintenance details, non-null
    TrainId INT NOT NULL,              -- Foreign key reference to Trains
    FOREIGN KEY (TrainId) REFERENCES Trains(Id)
);

-- Create the Tickets table
CREATE TABLE Tickets (
    Id INT IDENTITY PRIMARY KEY,  -- Primary key with auto-increment
    Price DECIMAL(18, 2) NOT NULL,     -- Ticket price, non-null
    DateOfDeparture DATE NOT NULL,     -- Date of departure, non-null
    DateOfArrival DATE NOT NULL,       -- Date of arrival, non-null
    TrainId INT NOT NULL,              -- Foreign key reference to Trains
    PassengerId INT NOT NULL,          -- Foreign key reference to Passengers
    FOREIGN KEY (TrainId) REFERENCES Trains(Id),
    FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);


--			2. Insert
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
			VALUES  ('07:00', '19:00',	1, 3 )
					,('08:30', '20:30',	5, 6 )
					,('09:00', '21:00',	4, 8 )
					,('06:45', '03:55',	27, 7)
					,('10:15', '12:15',	15, 5)

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
							   VALUES(36, 1)
									,(37, 60) 
									,(39, 3)
									,(36, 4)
									,(37, 16) 
									,(39, 31)
									,(36, 31) 
									,(38, 10) 
									,(39, 19)
									,(36, 57) 
									,(38, 50) 
									,(40, 41)
									,(36, 7)
									,(38, 52) 
									,(40, 7)
									,(37, 13) 
									,(38, 22) 
									,(40, 52)
									,(37, 54) 
									,(39, 68) 
									,(40, 13)

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
				VALUES	(90.00, '2023-12-01', '2023-12-01', 36, 1)
						,(115.00, '2023-08-02', '2023-08-02', 37, 2)
						,(160.00, '2023-08-03', '2023-08-03', 38, 3)
						,(255.00, '2023-09-01', '2023-09-02', 39, 21)
						,(95.00, '2023-09-02', '2023-09-03', 40, 22)


--			3. Update
UPDATE Tickets SET
	DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
	DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE
	DATEPART(MONTH, DateOfDeparture) > 10

--			4. Delete
DELETE 
	FROM Trains AS t
	WHERE DepartureTownId IN
		(SELECT Id 
		FROM Towns
		)