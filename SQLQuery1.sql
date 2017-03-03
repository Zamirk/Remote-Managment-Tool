

/*Get list of tables*/
 SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_TYPE='BASE TABLE'

 /*Droping tables*/
  drop table STAFF;
  drop table ListOfDevices;
  drop table Login;
  drop table Devices;

  /*Creating Login*/
 CREATE TABLE Login(
  Id nvarchar NOT NULL,
  Username Varchar(255) NOT NULL,
  Password Varchar(255) NOT NULL,
  Email Varchar(255) NOT NULL,
  PRIMARY KEY (Username));
  
  /*Altering table*/
  ALTER TABLE Login
  ADD Username Varchar(255) NOT NULL UNIQUE,
	  Password Varchar(255) NOT NULL,
	  Email Varchar(255) NOT NULL;

  /*Inserting into Login*/
 INSERT INTO dbo.Login(Username, Password, Email)VALUES('Admin','1234','123@123.com');
 INSERT INTO dbo.Devices(DeviceID, Username, ConnectionKey)VALUES('12213','Admin','conection key');

  /*Query Login*/
 SELECT Username, Password, Email FROM dbo.Login;
 SELECT * FROM dbo.Login;

  /*Creating Devices*/
 CREATE TABLE Devices(
  DeviceID Varchar(255) NOT NULL,
  Username Varchar(255) NOT NULL,
  ConnectionKey Varchar(255) NOT NULL,
  FOREIGN KEY (Username) REFERENCES Login(Username),
  PRIMARY KEY (DeviceID))

  create sequence device_seq start with 1 increment by 1 

   SELECT * FROM dbo.Login;
   SELECT * FROM dbo.Devices where Username = 'Admin';