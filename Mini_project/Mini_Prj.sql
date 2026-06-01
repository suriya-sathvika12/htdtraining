CREATE DATABASE RailwaySystemDB;
USE RailwaySystemDB;

--Train master table
CREATE TABLE TrainMaster
(
    TrainID INT PRIMARY KEY,
    TrainName VARCHAR(60),
    SourceStation VARCHAR(60),
    DestinationStation VARCHAR(60),
    SleeperSeats INT,
    AC2Seats INT,
    AC3Seats INT,
    SleeperFare DECIMAL(10,2),
    AC2Fare DECIMAL(10,2),
    AC3Fare DECIMAL(10,2),
    DepartureTime TIME,
    IsRemoved BIT DEFAULT 0,
    TrainStatus VARCHAR(15) DEFAULT 'Running'
);

--User table
CREATE TABLE UserAccounts
(
    UserName VARCHAR(50) PRIMARY KEY,
    UserPassword VARCHAR(50)
);

--Booking table
CREATE TABLE TicketBookings
(
    BookingID INT IDENTITY PRIMARY KEY,
    BookingDate DATE DEFAULT GETDATE(),
    JourneyDate DATE,
    TrainID INT,
    ClassType VARCHAR(10),
    TotalPassengers INT CHECK (TotalPassengers <= 3),
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (TrainID) REFERENCES TrainMaster(TrainID)
);

--Passenger table
CREATE TABLE PassengerInfo
(
    PassengerID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT,
    Name VARCHAR(100),
    Gender VARCHAR(10),
    Age INT,
    FOREIGN KEY (BookingID) REFERENCES TicketBookings(BookingID)
);

--Cancellation table
CREATE TABLE TicketCancellation
(
    CancelID INT IDENTITY PRIMARY KEY,
    BookingID INT,
    TicketsCancelled INT DEFAULT 1,
    RefundAmount DECIMAL(10,2),
    CancelledDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES TicketBookings(BookingID)
);

--Select table
SELECT * FROM TrainMaster;
SELECT * FROM TicketBookings;
SELECT * FROM TicketCancellation;
SELECT * FROM UserAccounts;
SELECT * FROM PassengerInfo;

CREATE USER [INFICS\suriyasa] FOR LOGIN [INFICS\suriyasa];
ALTER ROLE db_owner ADD MEMBER [INFICS\suriyasa];