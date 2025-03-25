﻿-- REPLACE YOUR DATABASE LOGIN AND PASSWORD IN THE SCRIPT BELOW

Use master
Go

-- Create a login for the admin user
CREATE LOGIN [TrainingHelperLogin] WITH PASSWORD ='123';
Go

--so user can restore the DB!
ALTER ROLE db_owner ADD MEMBER [TrainingHelperUser];
Go

Create Database TrainingHelperDb;