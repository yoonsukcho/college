/***********************************************************
* Create the database named memberdb and all of its tables
************************************************************/

DROP DATABASE IF EXISTS memberdb;
CREATE DATABASE memberdb;
USE memberdb;

CREATE TABLE Member (
	MemberID INT NOT NULL AUTO_INCREMENT,
	FullName VARCHAR(50),
	EmailAddress VARCHAR(50),
	PhoneNumber VARCHAR(20),
	ProgramName VARCHAR(20),
	YearLevel INT,
	PRIMARY KEY(MemberID) 
);

INSERT INTO Member 
  (FullName, EmailAddress, PhoneNumber, ProgramName, YearLevel)
VALUES 
  ('John Smith', 'jsmith@gmail.com', '111-111-1111', 'CPA', 1),
  ('Mary Smith', 'msmith@yahoo.com', '222-222-2222', 'CP', 2);