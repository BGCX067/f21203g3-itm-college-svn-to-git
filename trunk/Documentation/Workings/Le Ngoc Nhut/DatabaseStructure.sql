create database ITM
GO
use ITM
GO
create table Accounts
(
	accountID				INT	NOT NULL	IDENTITY(1,1)	Primary key,
	username				VARCHAR(32) NOT NULL,
	password				VARCHAR(32) NOT NULL,
	role					VARCHAR(10) NOT NULL
		
)
GO
create table Departments
(
	departmentID			INT	NOT NULL	IDENTITY(1,1)	Primary key,
	departmentName			VARCHAR(250) NOT NULL,
	departmentDescription	NVARCHAR(1000) NOT NULL,
	departmentImage			VARCHAR (250) NOT NULL,
	departmentOrder			INT NOT NULL,
	disable					BIT NOT NULL default 0 
)
GO
create table Faculty
(
	facultyID				INT	NOT NULL	IDENTITY(1,1)	Primary key,
	facultyName				VARCHAR(250) NOT NULL,
	facultyDescription		NVARCHAR(1000) NOT NULL,
	facultyOrder			INT NOT NULL default 0,
	facultyImage			VARCHAR(250) NOT NULL,
	departmentID			INT NOT NULL,
	disable					BIT NOT NULL default 0
)
GO
create table Courses
(
	courseID				INT	NOT NULL	IDENTITY(1,1) Primary key,
	courseName				VARCHAR(250) NOT NULL,
	courseDescription		NVARCHAR(1000) NOT NULL,
	departmentID			INT NOT NULL,
	facultyID				INT NOT NULL,
	startDate				VARCHAR(50) NOT NULL,
	endDate					VARCHAR(50) NOT NULL,
	examDate				VARCHAR(50) NOT NULL,
	disabled				INT NOT NULL default 0
)
GO
create table OnlineAdmission
(
	admissionID				INT	NOT NULL	IDENTITY(1,1) Primary key,
	Name					VARCHAR(250) NOT NULL,
	FatherName				VARCHAR(250) NOT NULL,	
	MortherName				VARCHAR(250) NOT NULL,	
	Birthday				VARCHAR(20)	NOT NULL,
	Gender					BIT	NOT NULL	default 0 ,
	ResidentialAddress		VARCHAR(250) NOT NULL,
	PermanentAddress		VARCHAR(250) NOT NULL,	
	prevSportsDetails		VARCHAR(250) NOT NULL,
	prevUniversity			VARCHAR(250) NOT NULL,
	prevEnrolNumber			VARCHAR(250) NOT NULL,
	prevCenter				VARCHAR(250) NOT NULL,
	prevStream				VARCHAR(250) NOT NULL,	
	prevField				VARCHAR(250) NOT NULL,	
	prevMarks				VARCHAR(250) NOT NULL,	
	prevOutOf				VARCHAR(250) NOT NULL,	
	prevClass				VARCHAR(250) NOT NULL,	
	status					BIT	NOT NULL default 0
)
GO
create table StudentRegistration
(
	registrationID			INT NOT NULL	IDENTITY(1,1) Primary key,
	specializedSubject		INT NOT NULL,
	optionalSubject			INT NOT NULL,
	courseID				INT NOT NULL,
	admissionID				INT NOT NULL,
	Password				VARCHAR(30) NOT NULL,
	enrollNumber			INT NOT NULL
)
GO
create table Assignments
(
	assignmentID			INT NOT NULL	IDENTITY(1,1) Primary key,
	assignmentName			VARCHAR(250) NOT NULL,
	assignmentDescription	NVARCHAR(1000) NOT NULL,
	courseID				INT NOT NULL
)
GO
create table FeedBacks
(
	feedbackID				INT NOT NULL	IDENTITY(1,1) Primary key,
	feedbackContent			NVARCHAR(1000) NOT NULL,
	courseID				INT NOT NULL
)
GO
create table Branches
(
	brancheID				INT NOT NULL	IDENTITY(1,1) Primary key,
	brancheName				VARCHAR(50) NOT NULL,
	brancheAddress			VARCHAR(250) NOT NULL,
	brancheEmail			VARCHAR(150) NOT NULL,
	branchePhone			VARCHAR(30) NOT NULL,
	brancheFax				VARCHAR(30) NOT NULL,
	Description				NVARCHAR(1000) NOT NULL
)
GO
create table CollegeContents
(
	contentID				INT NOT NULL	IDENTITY(1,1) Primary key,
	contentTitle			NVARCHAR(1000) NOT NULL,
	contentImage			VARCHAR(250) NOT NULL,
	contentText				NVARCHAR(1000) NOT NULL,
	contentCategory			VARCHAR(250) NOT NULL
)
GO
create table Facilities
(
	facilitieID				INT NOT NULL	IDENTITY(1,1) Primary key,
	facilitieName			NVARCHAR(1000) NOT NULL,
	facilitieImage			VARCHAR(250) NOT NULL,
	facilitieDescription	NVARCHAR(1000) NOT NULL
)