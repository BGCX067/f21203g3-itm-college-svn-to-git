USE [ITMCollege]
GO
/****** Object:  Table [dbo].[OnlineAdmission]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OnlineAdmission](
	[admissionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[FatherName] [varchar](250) NOT NULL,
	[MortherName] [varchar](250) NOT NULL,
	[Birthday] [varchar](20) NOT NULL,
	[Gender] [bit] NOT NULL,
	[ResidentialAddress] [varchar](250) NOT NULL,
	[PermanentAddress] [varchar](250) NOT NULL,
	[prevSportsDetails] [varchar](250) NOT NULL,
	[prevUniversity] [varchar](250) NOT NULL,
	[prevEnrolNumber] [varchar](250) NOT NULL,
	[prevCenter] [varchar](250) NOT NULL,
	[prevStream] [varchar](250) NOT NULL,
	[prevField] [varchar](250) NOT NULL,
	[prevMarks] [varchar](250) NOT NULL,
	[prevOutOf] [varchar](250) NOT NULL,
	[prevClass] [varchar](250) NOT NULL,
	[regKey] [varchar](32) NOT NULL,
	[status] [bit] NOT NULL,
	[admissionFor] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[admissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CollegeContents]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CollegeContents](
	[contentID] [int] IDENTITY(1,1) NOT NULL,
	[contentTitle] [nvarchar](1000) NOT NULL,
	[contentImage] [varchar](250) NOT NULL,
	[contentText] [text] NOT NULL,
	[contentCategory] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branches](
	[brancheID] [int] IDENTITY(1,1) NOT NULL,
	[brancheName] [varchar](50) NOT NULL,
	[brancheAddress] [varchar](250) NOT NULL,
	[brancheEmail] [varchar](150) NOT NULL,
	[branchePhone] [varchar](30) NOT NULL,
	[brancheFax] [varchar](30) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[brancheID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[accountID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](32) NOT NULL,
	[password] [varchar](32) NOT NULL,
	[role] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facilities]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facilities](
	[facilitieID] [int] IDENTITY(1,1) NOT NULL,
	[facilitieName] [nvarchar](1000) NOT NULL,
	[facilitieImage] [varchar](250) NOT NULL,
	[facilitieDescription] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facilitieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[departmentID] [int] IDENTITY(1,1) NOT NULL,
	[departmentName] [varchar](250) NOT NULL,
	[departmentDescription] [text] NULL,
	[departmentImage] [varchar](250) NOT NULL,
	[departmentOrder] [int] NOT NULL,
	[disable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [varchar](250) NOT NULL,
	[courseDescription] [nvarchar](1000) NOT NULL,
	[departmentID] [int] NOT NULL,
	[facultyID] [int] NOT NULL,
	[startDate] [varchar](50) NOT NULL,
	[endDate] [varchar](50) NOT NULL,
	[examDate] [varchar](50) NOT NULL,
	[disabled] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculty](
	[facultyID] [int] IDENTITY(1,1) NOT NULL,
	[facultyName] [varchar](250) NOT NULL,
	[facultyDescription] [text] NOT NULL,
	[facultyOrder] [int] NOT NULL,
	[facultyImage] [varchar](250) NOT NULL,
	[departmentID] [int] NOT NULL,
	[disable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facultyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentRegistration]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentRegistration](
	[registrationID] [int] IDENTITY(1,1) NOT NULL,
	[specializedSubject] [int] NOT NULL,
	[optionalSubject] [int] NOT NULL,
	[admissionID] [int] NOT NULL,
	[Password] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[registrationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeedBacks]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBacks](
	[feedbackID] [int] IDENTITY(1,1) NOT NULL,
	[feedbackContent] [nvarchar](1000) NOT NULL,
	[courseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[feedbackID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 05/24/2013 18:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assignments](
	[assignmentID] [int] IDENTITY(1,1) NOT NULL,
	[assignmentName] [varchar](250) NOT NULL,
	[assignmentDescription] [nvarchar](1000) NOT NULL,
	[courseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[assignmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__Courses__disable__276EDEB3]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Courses] ADD  DEFAULT ((0)) FOR [disabled]
GO
/****** Object:  Default [DF__Departmen__disab__286302EC]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Departments] ADD  DEFAULT ((0)) FOR [disable]
GO
/****** Object:  Default [DF__Faculty__faculty__29572725]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Faculty] ADD  DEFAULT ((0)) FOR [facultyOrder]
GO
/****** Object:  Default [DF__Faculty__disable__2A4B4B5E]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Faculty] ADD  DEFAULT ((0)) FOR [disable]
GO
/****** Object:  Default [DF__OnlineAdm__Gende__2B3F6F97]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[OnlineAdmission] ADD  DEFAULT ((0)) FOR [Gender]
GO
/****** Object:  Default [DF__OnlineAdm__statu__2C3393D0]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[OnlineAdmission] ADD  DEFAULT ((0)) FOR [status]
GO
/****** Object:  ForeignKey [FK_Assignments_Courses]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Courses]
GO
/****** Object:  ForeignKey [FK_Courses_Departments]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Departments] ([departmentID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
/****** Object:  ForeignKey [FK_Faculty_Departments]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Departments] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Departments] ([departmentID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_Departments]
GO
/****** Object:  ForeignKey [FK_FeedBacks_Courses]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[FeedBacks]  WITH CHECK ADD  CONSTRAINT [FK_FeedBacks_Courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[FeedBacks] CHECK CONSTRAINT [FK_FeedBacks_Courses]
GO
/****** Object:  ForeignKey [FK_StudentRegistration_OnlineAdmission]    Script Date: 05/24/2013 18:23:28 ******/
ALTER TABLE [dbo].[StudentRegistration]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegistration_OnlineAdmission] FOREIGN KEY([admissionID])
REFERENCES [dbo].[OnlineAdmission] ([admissionID])
GO
ALTER TABLE [dbo].[StudentRegistration] CHECK CONSTRAINT [FK_StudentRegistration_OnlineAdmission]
GO
GO
INSERT INTO Accounts VALUES
('admin', '21232f297a57a5a743894a0e4a801fc3', 'admin'),
('staff001', '1ef85d9969c3e29713566390a2e761b7', 'staff'),
('staff002', 'be66ba7a1565329e7e2a6727174e9d41', 'staff')