
USE Master
GO
IF EXISTS (SELECT name
 FROM Sysdatabases
 WHERE name = 'ITSD')
 BEGIN
 USE Master;
 ALTER DATABASE ITSD
 SET SINGLE_USER
 WITH ROLLBACK IMMEDIATE;
 DROP DATABASE ITSD;
 END
CREATE DATABASE ITSD;
GO
USE ITSD;
GO
CREATE TABLE ServiceRequest (
  id                 int IDENTITY NOT NULL, 
  type               varchar(30) NOT NULL, 
  status             varchar(30) NOT NULL, 
  reqeustMode        varchar(30) NOT NULL, 
  title              varchar(50) NOT NULL, 
  description        varchar(8000) NULL, 
  requester          int NOT NULL, 
  agent              int NOT NULL, 
  impact             varchar(10) NOT NULL, 
  urgency            varchar(30) NOT NULL, 
  priority           varchar(10) NOT NULL, 
  serviceItemId      int NOT NULL, 
  serviceAgreementId int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Change (
  id           int IDENTITY NOT NULL, 
  type         varchar(30) NOT NULL, 
  status       varchar(30) NOT NULL, 
  reqeustMode  varchar(30) NOT NULL, 
  title        varchar(50) NOT NULL, 
  description  varchar(8000) NULL, 
  requester    int NOT NULL, 
  agent        int NOT NULL, 
  impact       varchar(10) NOT NULL, 
  urgency      varchar(30) NOT NULL, 
  priority     varchar(10) NOT NULL, 
  category     varchar(30) NOT NULL, 
  changeRisk   int NOT NULL, 
  reason       varchar(8000) NULL, 
  implications varchar(255) NOT NULL, 
  rolloutPlan  varchar(255) NOT NULL, 
  backoutPlan  varchar(255) NOT NULL, 
  releaseInfo  varchar(255) NOT NULL, 
  risk         int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Problem (
  id                      int IDENTITY NOT NULL, 
  type                    varchar(30) NOT NULL, 
  status                  varchar(30) NOT NULL, 
  reqeustMode             varchar(30) NOT NULL, 
  title                   varchar(50) NOT NULL, 
  description             varchar(8000) NULL, 
  requester               int NOT NULL, 
  agent                   int NOT NULL, 
  impact                  varchar(10) NOT NULL, 
  urgency                 varchar(30) NOT NULL, 
  priority                varchar(10) NOT NULL, 
  rootCause               varchar(255) NOT NULL, 
  symtoms                 varchar(255) NOT NULL, 
  permSolutionTitle       varchar(255) NOT NULL, 
  permSolutionDescription varchar(8000) NULL, 
  workSolutionTitle       varchar(255) NOT NULL, 
  workSolutionDescription varchar(8000) NULL, 
  PRIMARY KEY (id));
CREATE TABLE Incident (
  id              int IDENTITY NOT NULL, 
  type            varchar(30) NOT NULL, 
  status          varchar(30) NOT NULL, 
  reqeustMode     varchar(30) NOT NULL, 
  title           varchar(50) NOT NULL, 
  description     varchar(8000) NULL, 
  requester       int NOT NULL, 
  agent           int NOT NULL, 
  impact          varchar(10) NOT NULL, 
  urgency         varchar(30) NOT NULL, 
  priority        varchar(10) NOT NULL, 
  nonErrorRecorId int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE EmployeeServiceTeam (
  employeeId    int NOT NULL, 
  serviceteamId int NOT NULL, 
  PRIMARY KEY (employeeId, 
  serviceteamId));
CREATE TABLE Serviceteam (
  id   int IDENTITY NOT NULL, 
  name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE Position (
  id   int IDENTITY NOT NULL, 
  name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE Location (
  id   int IDENTITY NOT NULL, 
  name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE Department (
  id   int IDENTITY NOT NULL, 
  name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE Employee (
  id                     int IDENTITY NOT NULL, 
  firstName              varchar(30) NOT NULL, 
  middleName             varchar(30) NULL, 
  lastName               varchar(30) NOT NULL, 
  employeeType           varchar(10) NOT NULL, 
  positionId             int NOT NULL, 
  departmentId           int NOT NULL, 
  locationId             int NOT NULL, 
  workEmail              varchar(50) NOT NULL, 
  workPhone              varchar(30) NOT NULL, 
  phoneExtension         varchar(10) NOT NULL, 
  note                   varchar(8000) NULL, 
  picture                varchar(255) NOT NULL, 
  servicetier            varchar(30) NOT NULL, 
  servicedeskPosition    varchar(30) NOT NULL, 
  privateEmail           varchar(50) NOT NULL, 
  privatePhone           varchar(30) NOT NULL, 
  businessImpact         varchar(10) NOT NULL, 
  VIP                    bit NOT NULL, 
  serviceRequestApprover bit NOT NULL, 
  POApprover             bit NOT NULL, 
  PRIMARY KEY (id));
ALTER TABLE Employee ADD CONSTRAINT FKEmployee21894 FOREIGN KEY (departmentId) REFERENCES Department (id);
ALTER TABLE Employee ADD CONSTRAINT FKEmployee362805 FOREIGN KEY (positionId) REFERENCES Position (id);
ALTER TABLE Employee ADD CONSTRAINT FKEmployee674756 FOREIGN KEY (locationId) REFERENCES Location (id);
ALTER TABLE EmployeeServiceTeam ADD CONSTRAINT FKEmployeeSe184951 FOREIGN KEY (serviceteamId) REFERENCES Serviceteam (id);
ALTER TABLE EmployeeServiceTeam ADD CONSTRAINT FKEmployeeSe351122 FOREIGN KEY (employeeId) REFERENCES Employee (id);
ALTER TABLE Change ADD CONSTRAINT FKChange902496 FOREIGN KEY (agent) REFERENCES Employee (id);
ALTER TABLE Change ADD CONSTRAINT FKChange718544 FOREIGN KEY (requester) REFERENCES Employee (id);
ALTER TABLE Incident ADD CONSTRAINT FKIncident681166 FOREIGN KEY (requester) REFERENCES Employee (id);
ALTER TABLE Incident ADD CONSTRAINT FKIncident497214 FOREIGN KEY (agent) REFERENCES Employee (id);
ALTER TABLE ServiceRequest ADD CONSTRAINT FKServiceReq240102 FOREIGN KEY (requester) REFERENCES Employee (id);
ALTER TABLE ServiceRequest ADD CONSTRAINT FKServiceReq943849 FOREIGN KEY (agent) REFERENCES Employee (id);
ALTER TABLE Problem ADD CONSTRAINT FKProblem806199 FOREIGN KEY (requester) REFERENCES Employee (id);
ALTER TABLE Problem ADD CONSTRAINT FKProblem990151 FOREIGN KEY (agent) REFERENCES Employee (id);

