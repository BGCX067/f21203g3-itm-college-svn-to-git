using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : StudentManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Student Manage
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class StudentManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Insert Student Feedback
        /// </summary>
        /// <param name="content"></param>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public Boolean SendFeedBack(string content, int courseid)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO FeedBacks VALUES('"+content+"', "+courseid+")", _db.sqlcon);
                _db.ds = new DataSet();
                _db.sqlda.Fill(_db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// get student course by main and optional course id
        /// </summary>
        /// <param name="mainCourse"></param>
        /// <param name="optionalCourse"></param>
        /// <returns></returns>
        public DataSet GetStudentCourse(int mainCourse, int optionalCourse)
        {
            _db.sqlda = new SqlDataAdapter("SELECT courseID, courseName FROM Courses WHERE courseID IN("+mainCourse+","+optionalCourse+") AND disabled=0", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;

        }

        /// <summary>
        /// Change student password
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean ChangePassword(int studentId, string password)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE StudentRegistration SET Password='" + password + "' WHERE registrationID="+studentId, _db.sqlcon);
                _db.ds = new DataSet();
                _db.sqlda.Fill(_db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrive assignment list
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetAssignmentList(int studentId, string type)
        {
            string sqlQuery = "SELECT crs.courseName, crs.courseID, ass.* ";
            sqlQuery += "FROM StudentRegistration as std ";
            if (type == "specialized")
            {
                sqlQuery += "INNER JOIN Courses AS crs ON std.specializedSubject = crs.courseID ";
            }
            else if (type == "optional")
            {
                sqlQuery += "INNER JOIN Courses AS crs ON std.optionalSubject = crs.courseID ";
            }
            sqlQuery += "INNER JOIN Assignments as ass ON std.specializedSubject = ass.courseID ";
            sqlQuery += "WHERE std.registrationID = "+studentId;
            sqlQuery += " ORDER BY ass.assignmentID DESC";
            _db.sqlda = new SqlDataAdapter(sqlQuery, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Get Exam Time Table Detail
        /// </summary>
        /// <param name="studentId">Student ID, registered course</param>
        /// <param name="type">
        /// - specialized for specializedSubject
        /// - optional for optionalSubject
        /// </param>
        /// <returns></returns>
        public DataSet GetExamTable(int studentId, string type)
        {
            string sqlQuery =
                "SELECT course.courseID, course.courseName, course.examDate, dep.departmentName, course.startDate, course.endDate, fal.facultyName FROM StudentRegistration as student ";
            if (type == "specialized")
            {
                sqlQuery += "INNER JOIN Courses as course ON student.specializedSubject = course.courseID ";
            }
            else if (type == "optional")
            {
                sqlQuery += "INNER JOIN Courses as course ON student.optionalSubject = course.courseID ";
            }
            sqlQuery += "INNER JOIN Faculty as fal ON course.facultyID = fal.facultyID ";
            sqlQuery += "INNER JOIN Departments as dep On course.departmentID = dep.departmentID ";
            sqlQuery += "WHERE student.registrationID=" + studentId;
            _db.sqlda = new SqlDataAdapter(sqlQuery, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Get student information by student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public DataSet FetchStudent(int studentId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM StudentRegistration INNER JOIN OnlineAdmission ON StudentRegistration.admissionID = OnlineAdmission.admissionID WHERE registrationID=" + studentId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Check Student login
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataSet StudentLogin(int studentId, string password)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM StudentRegistration WHERE registrationID=" + studentId + " AND Password='"+password+"'", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
    }
}
