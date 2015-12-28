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
    /// Class	 : FacultyManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Faculty methods
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FacultyManage
    {
        readonly Database _db = new Database();

        /// <summary>
        /// Get Faculty by Department
        /// </summary>
        /// <param name="depId">Int departmentId</param>
        /// <returns></returns>
        public DataSet GetFacultyByDepartment(int depId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Faculty WHERE departmentID=" + depId + " AND disable=0 ORDER BY facultyID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method GetFaculty
        /// </summary>
        /// <remarks></remarks>
        /// <returns>
        /// Faculty in dataset
        /// </returns>
        public DataSet GetFaculty()
        {
            _db.sqlda = new SqlDataAdapter("SELECT  Faculty.*,  Departments.departmentID, Departments.departmentName FROM  Faculty INNER JOIN  Departments ON  Faculty.departmentID =  Departments.departmentID WHERE Departments.disable=0 and Faculty.disable=0 ORDER BY Faculty.facultyID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method FetchFaculty
        /// Get Faculty detail
        /// </summary>
        /// <param name="facultyId">The Faculty to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Faculty in dataset
        /// </returns>
        public DataSet FetchFaculty(int facultyId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Faculty WHERE facultyID=" + facultyId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Insert new Faculty into database
        /// </summary>
        /// <param name="facultyName">String new facultyName</param>
        /// <param name="facultyDescription">String new facultyDescription</param>
        /// <param name="facultyOrder">Int new facultyOrder</param>
        /// <param name="facultyImage">String new facultyImage</param>
        /// <param name="departmentId">Int new departmentID</param>
        /// <returns>Boolean true if Faculty inserted</returns>
        public Boolean InsertFaculty(string facultyName, string facultyDescription, int facultyOrder, string facultyImage, int departmentId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Faculty VALUES ('" + facultyName + "','" + facultyDescription + "','" + facultyOrder + "','" + facultyImage + "','"+departmentId+"',0)", _db.sqlcon);
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
        /// Method UpdateFaculty
        /// Get Faculty detail
        /// </summary>
        /// <param name="facultyId">The facultyID to fetch detail</param>
        /// <param name="facultyName">String new facultyName</param>
        /// <param name="facultyDescription">String new facultyDescription</param>
        /// <param name="facultyOrder">Int new facultyOrder</param>
        /// <param name="facultyImage">String new facultyImage</param>
        /// <param name="departmentId">Int new departmentID</param>
        /// <remarks></remarks>
        /// <returns>
        /// Faculty in dataset
        /// </returns>
        public Boolean UpdateFaculty(int facultyId, string facultyName, string facultyDescription, int facultyOrder, string facultyImage, int departmentId)
        {

            try
            {
                string sqlQuery = "UPDATE Faculty SET facultyName = '" + facultyName + "' , facultyDescription ='" + facultyDescription + "' , facultyOrder = '" + facultyOrder + "', facultyImage ='" + facultyImage + "',departmentID = '"+departmentId+"'";
                sqlQuery += " WHERE facultyID=" + facultyId;
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
        /// Delete an Faculty
        /// </summary>
        /// <param name="facultyId">Int facultyID id</param>
        public Boolean DeleteFaculty(int facultyId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE Faculty SET disable = 1 WHERE facultyID =" + facultyId, _db.sqlcon);
                _db.ds = new DataSet();
                _db.sqlda.Fill(_db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
