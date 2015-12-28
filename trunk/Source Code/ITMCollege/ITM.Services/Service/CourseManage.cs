using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : CourseManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Course Manage
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CourseManage
    {
        readonly Database _db = new Database();

        /// <summary>
        /// Get available course by department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataSet GetCourseByDepartmentId(int departmentId)
        {
            var sqlQuery =
                "SELECT Courses.*, Departments.departmentName, Faculty.facultyName FROM Courses INNER JOIN Departments ON Courses.departmentID = Departments.departmentID INNER JOIN Faculty ON Courses.facultyID = Faculty.facultyID WHERE disabled=0 AND Courses.departmentID="+departmentId;
            _db.sqlda = new SqlDataAdapter(sqlQuery, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method GetCourses
        /// </summary>
        /// <remarks></remarks>
        public DataSet GetCourses()
        {
            _db.sqlda = new SqlDataAdapter("SELECT Courses.*, Faculty.facultyName FROM Courses INNER JOIN Faculty ON Courses.facultyID = Faculty.facultyID WHERE Courses.disabled=0 ORDER BY Courses.courseID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method FetchCourses
        /// Get course detail
        /// </summary>
        /// <param name="courseId">The courseId to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// course in dataset
        /// </returns>
        public DataSet FetchCourses(int courseId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Courses WHERE courseID=" + courseId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName">string courseName</param>
        /// <param name="courseDescription"> string courseDescription</param>
        /// <param name="departmentId">int departmentId</param>
        /// <param name="facultyId">int facultyId</param>
        /// <param name="startDate">string startDate</param>
        /// <param name="endDate">string endDate</param>
        /// <param name="examDate">string examDate</param>
        /// <returns>boollean true if Course inserted</returns>
        public Boolean InsertCourse(string courseName, string courseDescription, int departmentId, int facultyId, string startDate, string endDate, string examDate)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Courses VALUES ('" + courseName + "','" + courseDescription + "','" + departmentId + "', '" + facultyId + "','" + startDate + "','" + endDate + "','" + examDate + "',0)", _db.sqlcon);
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
        /// Delete an Courses
        /// </summary>
        /// <param name="courseID">Int courseID id</param>
        public Boolean DeleteCourse(int courseId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE Courses SET disabled = 1 WHERE courseID =" + courseId, _db.sqlcon);
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
        /// Method Update Course
        /// </summary>
        /// <param name="courseId">The courseId to fetch detail</param>
        /// <param name="courseName">string courseName</param>
        /// <param name="courseDescription">string courseDescription</param>
        /// <param name="departmentId">int departmentId</param>
        /// <param name="facultyId">int facultyId</param>
        /// <param name="startDate">string startDate</param>
        /// <param name="endDate">string endDate</param>
        /// <param name="examDate">string examDate</param>
        /// <returns>Boolean true if Course Update</returns>
        public Boolean UpdateCourse(int courseId, string courseName, string courseDescription, int departmentId, int facultyId, string startDate, string endDate, string examDate)
        {

            try
            {
                string sqlQuery = "UPDATE Courses SET courseName = '" + courseName + "' , courseDescription ='" + courseDescription + "' , departmentID ='" + departmentId + "', facultyID = '" + facultyId + "', startDate = '" + startDate + "', endDate = '" + endDate + "', examDate = '" + examDate + "'";
                sqlQuery += " WHERE courseID=" + courseId;
                _db.sqlda = new SqlDataAdapter(sqlQuery, _db.sqlcon);
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
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataSet SearchCourses(int departmentId,string name)
        {
            _db.sqlda = new SqlDataAdapter("select * from Courses where departmentID = " + departmentId + " and courseName like '%" + name + "%'", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
    }
}
