use master
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

CREATE TABLE Trainee (
		TraineeId int identity(1000,1) Primary KEY ,
		Id nvarchar (225) unique Not null,
		FirstName nvarchar (20) Not null ,
		LastName nvarchar (225) Not null,
		SubscriptionStartDate Datetime ,
		SubscriptionEndDate Datetime  ,
		BirthDate Datetime ,
		Gender nvarchar (225) ,
		PhoneNum nvarchar (225) ,
		Email nvarchar (225) ,
		Picture nvarchar (225),
		Password nvarchar (225),
		);

CREATE TABLE [Owner] (
		OwnerId nvarchar (225) Primary KEY Not null,
		Email nvarchar (225) Not null,
		FirstName nvarchar (225) Not null,
		LastName nvarchar (225) Not null,		
		);

		
CREATE TABLE Trainer (
		TrainerId int identity(1000,1) Primary KEY Not null,
		Id nvarchar (225) unique Not null,
		FirstName nvarchar (20) Not null ,
		LastName nvarchar (225) Not null,
		BirthDate Date Not null,
		Gender nvarchar (225) Not null,
		PhoneNum nvarchar (225) Not null,
		Email nvarchar (225)  Not null,
		Picture nvarchar (225),
		Password nvarchar (225),
		);

CREATE TABLE Training (
		TrainingNumber int identity(1000,1) Primary KEY Not null,
		TrainerId int Foreign key REFERENCES Trainer(TrainerId),
		MaxParticipants int Not null,
		Place nvarchar (225) Not null,
		[Date] Datetime, 
		Duration nvarchar (225) Not null,
		Picture nvarchar (225) Not null,
		);

CREATE TABLE TraineesInPractice (
		TraineeId int  Foreign key REFERENCES Trainee(TraineeID), 
		TrainingNumber int  Foreign key REFERENCES Training(TrainingNumber) ,
		HasArrived bit Not null default 0,
		);



	
CREATE TABLE TrainingPictures( 
		PictureId nvarchar (225) Primary Key,
		TrainingNumber int Foreign key REFERENCES Training(TrainingNumber),
		PictureEnding nvarchar (225) Not null,
		);
		 
CREATE TABLE TrainingField(
		TrainingFieldId int Primary KEY Not null,
		Field nvarchar (225) Not null,
		);

CREATE TABLE TrainingFieldsInTrainer(
		TrainerId int Foreign key REFERENCES Trainer(TrainerId),
		TrainingFieldId int Foreign key REFERENCES TrainingField(TrainingFieldId),
		);

CREATE TABLE TrainingFieldsInTraining(
		TrainingFieldId int Foreign key REFERENCES TrainingField(TrainingFieldId),
		TrainingNumber int Foreign key REFERENCES Training(TrainingNumber),
		);



--INSERT INTO Owner (OwnerId,Email,FirstName,LastName) VALUES (1,'a@a.com','Amit','c')
--INSERT INTO Owner (OwnerId,Email,FirstName,LastName) VALUES (2,'S@a.com','dmit','b')

INSERT INTO Trainee (Id,FirstName,LastName,Password, BirthDate) VALUES(223,'Amit','C',223,'20-aug-2007')

---
CREATE LOGIN [TrainingHelperLogin] WITH PASSWORD ='123';
---           TrainingHelperLogin
Go

CREATE USER [TrainingHelperUser] FOR LOGIN
[TrainingHelperLogin];

Go

Select * From Trainee

ALTER ROLE db_owner ADD MEMBER [TrainingHelperUser];

Go




--v