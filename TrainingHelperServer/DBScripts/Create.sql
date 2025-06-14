﻿use master
go

IF EXISTS (SELECT * FROM sys.databases WHERE name = N'TrainingHelperDb')

BEGIN

DROP DATABASE TrainingHelperDb;

END

Go

CREATE DATABASE TrainingHelperDb;
Go

Use TrainingHelperDb;
Go
CREATE TABLE Owner (
		OwnerId nvarchar (225) Primary KEY Not null,
		Password nvarchar (225) Not null ,--changed 
		FirstName nvarchar (225) Not null,
		LastName nvarchar (225) Not null,		
		);

CREATE TABLE Trainer (
    TrainerId INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
    Id NVARCHAR(225) UNIQUE NOT NULL,
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(225) NOT NULL,
    BirthDate DATE NOT NULL,
    Gender NVARCHAR(225) NOT NULL,
    PhoneNum NVARCHAR(225) NOT NULL,
    Email NVARCHAR(225) NOT NULL,
    Picture NVARCHAR(225),
    Password NVARCHAR(225),
    IsActive BIT NOT NULL DEFAULT 1
);

-- Create Trainee table
CREATE TABLE Trainee (
    TraineeId INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
    Id NVARCHAR(225) UNIQUE NOT NULL,
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(225) NOT NULL,
    SubscriptionStartDate DATETIME,
    SubscriptionEndDate DATETIME,
    BirthDate DATETIME NOT NULL,
    Gender NVARCHAR(225),
    PhoneNum NVARCHAR(225),
    Email NVARCHAR(225),
    Picture NVARCHAR(225),
    Password NVARCHAR(225),
    IsActive BIT NOT NULL DEFAULT 1
);
INSERT INTO Trainee (Id,FirstName,LastName,Password, BirthDate,Email,Gender,PhoneNum,Picture,SubscriptionStartDate,SubscriptionEndDate) VALUES(223,'Amit','C',223,'20-aug-2007','amitchachan1@gmail.com','m','0500000000','.jpg','29-aug-2024','29-aug-2025')
INSERT INTO Trainee (Id,FirstName,LastName,Password, BirthDate,Email,Gender,PhoneNum,Picture,SubscriptionStartDate,SubscriptionEndDate) VALUES(223223223,'Amit','C','223a','20-aug-2007','s@s.com','m','0506666666','.jpg','29-aug-2024','29-aug-2025')

-- Create TrainingField table
CREATE TABLE TrainingField (
    TrainingFieldId INT PRIMARY KEY NOT NULL,
    Field NVARCHAR(225) NOT NULL
);

-- Create Training table
CREATE TABLE Training (
    TrainingNumber INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
    TrainerId INT FOREIGN KEY REFERENCES Trainer(TrainerId),
    MaxParticipants INT NOT NULL,
    Place NVARCHAR(225) NOT NULL,
    [Date] DATETIME NOT NULL,
    Duration NVARCHAR(225) NOT NULL,
    Picture NVARCHAR(225) NOT NULL
);

-- Create TraineesInPractice table
CREATE TABLE TraineesInPractice (


    TraineeId INT FOREIGN KEY REFERENCES Trainee(TraineeId),
    TrainingNumber INT FOREIGN KEY REFERENCES Training(TrainingNumber),
    PRIMARY KEY (TraineeId, TrainingNumber),
    HasArrived BIT NOT NULL DEFAULT 0
);

-- Create TrainingPictures table
CREATE TABLE TrainingPictures (
    PictureId NVARCHAR(225) PRIMARY KEY,
    TrainingNumber INT FOREIGN KEY REFERENCES Training(TrainingNumber),
    PictureEnding NVARCHAR(225) NOT NULL
);

-- Create TrainingFieldsInTrainer table
CREATE TABLE TrainingFieldsInTrainer (
    TrainerId INT FOREIGN KEY REFERENCES Trainer(TrainerId),
    TrainingFieldId INT FOREIGN KEY REFERENCES TrainingField(TrainingFieldId)
);

-- Create TrainingFieldsInTraining table
CREATE TABLE TrainingFieldsInTraining (
    TrainingFieldId INT FOREIGN KEY REFERENCES TrainingField(TrainingFieldId),
    TrainingNumber INT FOREIGN KEY REFERENCES Training(TrainingNumber)
);

-- Insert data into Trainer
INSERT INTO Trainer (Id, FirstName, LastName, BirthDate, Gender, PhoneNum, Email, Picture, Password)
VALUES
('1', 'John', 'Doe', '1985-07-15', 'Male', '1234567890', 'john.doe@example.com', 'john.png', 'password1'),
('2', 'Jane', 'Smith', '1990-05-20', 'Female', '0987654321', 'jane.smith@example.com', 'jane.png', 'password2'),
('3', 'Alex', 'Taylor', '1988-03-25', 'Non-Binary', '5551234567', 'alex.taylor@example.com', 'alex.png', 'password3');

-- Insert data into Trainee
INSERT INTO Trainee (Id, FirstName, LastName, PhoneNum, Email)
VALUES
('T1', 'Alice', 'Johnson', '1112223333', 'alice.johnson@example.com'),
('T2', 'Bob', 'Williams', '2223334444', 'bob.williams@example.com'),
('T3', 'Charlie', 'Brown', '3334445555', 'charlie.brown@example.com'),
('330845256' ,'Guy','Jaffe','0546884256','jaffe1@gmail.com'),
('330624289' ,'Ran','Nuriely','0589845216','ran@gmail.com');

-- Insert data into TrainingField
INSERT INTO TrainingField (TrainingFieldId, Field)
VALUES
(1, 'Yoga'),
(2, 'BJJ'),
(3, 'Muay Thai'),
(4, 'Boxing'),
(5, 'Calisthenics');

-- Insert data into Training
INSERT INTO Training (TrainerId, MaxParticipants, Place, [Date], Duration, Picture)
VALUES
(1000, 20, 'Studio A', '2025-01-15 10:00:00', '1 Hour', 'yoga_training.png'),
(1001, 15, 'Studio B', '2025-01-16 14:00:00', '1.5 Hours', 'bjj_training.png'),
(1002, 25, 'Studio C', '2025-01-17 18:00:00', '2 Hours', 'muay_thai_training.png'),
(1000, 20, 'Studio D', '2025-01-18 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio E', '2025-01-19 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio F', '2025-01-23 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio G', '2025-01-24 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio H', '2025-01-25 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio I', '2025-01-26 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio J', '2025-01-16 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio K', '2025-01-15 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio L', '2025-01-16 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio M', '2025-01-15 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio N', '2025-01-16 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio O', '2025-01-15 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio P', '2025-01-16 09:00:00', '1 Hour', 'boxing_training.png'),
(1002, 15, 'Studio Q', '2025-01-15 11:00:00', '1.5 Hours', 'calisthenics_training.png'),
(1000, 20, 'Studio R', '2025-01-16 09:00:00', '1 Hour', 'boxing_training.png');



-- Insert data into TrainingFieldsInTrainer
INSERT INTO TrainingFieldsInTrainer (TrainerId, TrainingFieldId)
VALUES
(1000, 1), -- John -> Yoga
(1001, 2), -- Jane -> BJJ
(1002, 3); -- Alex -> Muay Thai

-- Insert data into TrainingFieldsInTraining
INSERT INTO TrainingFieldsInTraining (TrainingFieldId, TrainingNumber)
VALUES
(1, 1000), -- Yoga -> Training 1
(2, 1001), -- BJJ -> Training 2
(3, 1002), -- Muay Thai -> Training 3
(4, 1003), -- Boxing -> Training 4
(5, 1004); -- Calisthenics -> Training 5

-- Insert data into TrainingPictures
INSERT INTO TrainingPictures (PictureId, TrainingNumber, PictureEnding)
VALUES
('P1', 1000, 'yoga1.jpg'),
('P2', 1001, 'bjj1.jpg'),
('P3', 1002, 'muay_thai1.jpg'),
('P4', 1003, 'boxing1.jpg'),
('P5', 1004, 'calisthenics1.jpg');

-- Insert data into TraineesInPractice
INSERT INTO TraineesInPractice (TraineeId, TrainingNumber, HasArrived)
VALUES
(1000, 1000, 1), -- Alice -> Yoga Training
(1001, 1001, 0), -- Bob -> BJJ Training
(1002, 1002, 1); -- Charlie -> Muay Thai Training


INSERT INTO Owner (OwnerId,Password,FirstName,LastName) VALUES (2,'2','dmit','b')
INSERT INTO Owner (OwnerId,Password,FirstName,LastName) VALUES (217327741,'a1','Amit','Chacham')

INSERT INTO Trainee (Id,FirstName,LastName,Password, BirthDate,Email,PhoneNum) VALUES('333','Amit','b','333','20-aug-2000','amitchachan1@gmail.com','0')

---
CREATE LOGIN [TrainingHelperLogin] WITH PASSWORD ='123';
---           TrainingHelperLogin
Go
--so user can restore the DB!
ALTER SERVER ROLE sysadmin ADD MEMBER [TrainingHelperLogin];
Go
CREATE USER [TrainingHelperUser] FOR LOGIN
[TrainingHelperLogin];

Go
-- Add the user to the db_owner role to grant admin privileges
ALTER ROLE db_owner ADD MEMBER [TrainingHelperUser];
Go






Select * From Trainee

Select * From Trainer

select * from Training



select * from TraineesInPractice

select * from Owner


Go




--scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=TrainingHelperDb;User ID=TrainingHelperLogin;Password=123;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context TrainingHelperDbContext -DataAnnotations –force