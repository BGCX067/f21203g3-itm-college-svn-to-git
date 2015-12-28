ALTER TABLE StudentRegistration
DROP CONSTRAINT FK_StudentRegistration_Courses
GO
ALTER TABLE StudentRegistration
DROP COLUMN courseID
GO
ALTER TABLE StudentRegistration
DROP COLUMN enrollNumber
GO
ALTER TABLE StudentRegistration
ALTER COLUMN Password VARCHAR(32)