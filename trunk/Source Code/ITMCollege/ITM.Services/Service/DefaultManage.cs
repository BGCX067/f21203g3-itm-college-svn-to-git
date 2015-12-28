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
    /// Class	 : DefaultManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Default page contents
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 23 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DefaultManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Get latest course
        /// </summary>
        /// <returns></returns>
        public DataSet GetLatestCourse()
        {
            _db.sqlda = new SqlDataAdapter("SELECT TOP 1 Courses.*, Faculty.* FROM Courses INNER JOIN Faculty ON Courses.facultyID = Faculty.facultyID WHERE Courses.disabled = 0 ORDER BY Courses.courseID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Get latest contents
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetContents(string type)
        {
            string sqlQuery = "SELECT TOP 3 * FROM CollegeContents ";
            switch (type)
            {
                case "news":
                    sqlQuery += "WHERE contentCategory = 'news'";
                    break;
                case "events":
                    sqlQuery += "WHERE contentCategory = 'events'";
                    break;
                case "achievements":
                    sqlQuery += "WHERE contentCategory = 'achievements'";
                    break;
                case "merit":
                    sqlQuery += "WHERE contentCategory = 'merit'";
                    break;
            }
            sqlQuery += " ORDER BY contentID DESC";
            _db.sqlda = new SqlDataAdapter(sqlQuery, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
    }
}
