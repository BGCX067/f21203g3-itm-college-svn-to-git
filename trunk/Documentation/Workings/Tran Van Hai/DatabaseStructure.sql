create database ITM
use ITM
create table Accounts
(
	accountID				INT	NOT NULL	IDENTITY(1,1)	Primary key,
	username				VARCHAR(32) NOT NULL,
	password				VARCHAR(32) NOT NULL,
	role					VARCHAR(10) NOT NULL
		
)
create table Departments
(
	departmentID			INT	NOT NULL	IDENTITY(1,1)	Primary key,
	departmentName			VARCHAR(250) NOT NULL,
	departmentDescription	Text(1000) NOT NULL,
	departmentImage			VARCHAR (250) NOT NULL,
	departmentOrder			INT NOT NULL default 0,
	disable					BIT NOT NULL default 0 
)
create table Faculty
(
	facultyID				INT	NOT NULL	IDENTITY(1,1)	Primary key,
	facultyName				VARCHAR(250) NOT NULL,
	facultyDescription		Text(1000) NOT NULL,
	facultyOrder			INT NOT NULL default 0,
	facultyImage			VARCHAR(250) NOT NULL,
	departmentID			INT NOT NULL,
	disable					BIT NOT NULL default 0
)
create table Courses
(
	courseID				INT	NOT NULL	IDENTITY(1,1) Primary key,
	courseName				VARCHAR(250) NOT NULL,
	courseDescription		Text(1000) NOT NULL,
	departmentID			INT NOT NULL,
	disabled				INT NOT NULL default 0,
)
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
	departmentID			INT	NOT NULL,
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
create table StudentRegistration
(
	registrationID			INT NOT NULL	IDENTITY(1,1) Primary key,
	specializedSubject		INT NOT NULL,
	optionalSubject			INT NOT NULL,
	admissionID				INT NOT NULL,
	Password				VARCHAR(250) NOT NULL,
	enrollNumber			VARCHAR(250) NOT NULL
)
create table TimeTable
(
	TimeTableID				INT NOT NULL	IDENTITY(1,1) Primary key,
	courseID				INT NOT NULL,
	facultyID				INT NOT NULL,
	startDate				DATETIME NOT NULL,
	endDate					DATETIME NOT NULL,
	available				BIT	NOT NULL default 0,
	disable					BIT NOT NULL default 0
)
create table Assignments
(
	AssignmentID			INT NOT NULL	IDENTITY(1,1) Primary key,
	AssignmentName			VARCHAR(250) NOT NULL,
	AssignmentDescription	TEXT(1000) NOT NULL,
	TimeTableID				INT NOT NULL
)
create table ExamTimeTable
(
	examID					INT NOT NULL	IDENTITY(1,1) Primary key,
	TimeTableID				INT NOT NULL,
	examDate				DATETIME NOT NULL,
	examTime				INT NOT NULL,
	examDuration			INT NOT NULL,
	examDescription			TEXT(1000) NOT NULL,
	disable					BIT NOT NULL default 0
)
create table ClassNews
(
	newsID					INT NOT NULL	IDENTITY(1,1) Primary key,
	newsTitle				VARCHAR(250) NOT NULL,
	newsImage				VARCHAR(250) NOT NULL,
	newsContent				TEXT(1000) NOT NULL,
	TimeTableID				INT NOT NULL
)
create table FeedBacks
(
	feedbackID				INT NOT NULL	IDENTITY(1,1) Primary key,
	feedbackContent			TEXT(1000) NOT NULL,
	TimeTableID				INT NOT NULL
)
create table Branches
(
	brancheID				INT NOT NULL	IDENTITY(1,1) Primary key,
	brancheName				VARCHAR(250) NOT NULL,
	brancheAddress			VARCHAR(100) NOT NULL,
	brancheEmail			VARCHAR(100) NOT NULL,
	branchePhone			VARCHAR(50) NOT NULL,
	brancheFax				VARCHAR(50) NOT NULL,
	Description				TEXT(1000) NOT NULL
)
create table CollegeContents
(
	contentID				INT NOT NULL	IDENTITY(1,1) Primary key,
	contentTitle			VARCHAR(250) NOT NULL,
	contentImage			VARCHAR(250) NOT NULL,
	contentText				TEXT(1000) NOT NULL,
	contentCategory			VARCHAR(250) NOT NULL
)
create table Facilities
(
	facilitieID				INT NOT NULL	IDENTITY(1,1) Primary key,
	facilitieName			VARCHAR(250) NOT NULL,
	facilitieImage			VARCHAR(250) NOT NULL,
	facilitieDescription	TEXT(1000) NOT NULL
)