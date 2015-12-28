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
    /// Class	 : DepartermentManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Departerment Manage
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 23 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DepartermentManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Method GetDepartments
        /// </summary>
        /// <remarks></remarks>
        /// <returns>
        /// Departments in dataset
        /// </returns>
        public DataSet GetDepartments()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Departments WHERE disable=0 ORDER BY departmentOrder ASC, departmentId DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method FetchDepartments
        /// Get Departments detail
        /// </summary>
        /// <param name="departmentId">The Departments to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Departments in dataset
        /// </returns>
        public DataSet FetchDepartments(int departmentId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Departments WHERE departmentID=" + departmentId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method UpdateDepartments
        /// Get Departments detail
        /// </summary>
        /// <param name="departmentId">The departmentsID to fetch detail</param>
        /// <param name="departmentName">String encrypted departmentName</param>
        /// <param name="departmentDescription">String role of departmentDescription</param>
        /// <param name="departmentOrder">Int new departmentOrder</param>
        /// <remarks></remarks>
        /// <returns>
        /// Department in dataset
        /// </returns>
        public Boolean UpdateDepartments(int departmentId, string departmentName, string departmentDescription,string departmentImage,  int departmentOrder)
        {
            
            try
            {
                string sqlQuery = "UPDATE Departments SET departmentName = '" + departmentName + "' , departmentDescription ='" + departmentDescription + "' , departmentImage ='"+departmentImage+"', departmentOrder = '" + departmentOrder + "'";
                sqlQuery += " WHERE departmentID=" + departmentId;
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
        /// Insert new Departments into database
        /// </summary>
        /// <param name="departmentName">String encrypted departmentName</param>
        /// <param name="departmentDescription">String role of departmentDescription</param>
        /// <param name="departmentImage"></param>
        /// <param name="departmentOrder">Int new departmentOrder</param>
        /// <returns>Boolean true if Departments inserted</returns>
        public Boolean InsertDepartments(string departmentName, string departmentDescription,string departmentImage, int departmentOrder)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Departments VALUES ('" + departmentName + "','" + departmentDescription + "','" + departmentImage + "','" + departmentOrder + "',0)", _db.sqlcon);
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
        /// Delete an Departments
        /// </summary>
        /// <param name="departmentId">Int Departments id</param>
        public Boolean DeleteDepartments(int departmentId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE Departments SET disable = 1 WHERE departmentID =" + departmentId, _db.sqlcon);
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
