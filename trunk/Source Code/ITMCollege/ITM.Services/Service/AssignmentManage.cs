using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ITM.Services.Service
{
    public class AssignmentManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Method GetAssignment
        /// </summary>
        /// <remarks></remarks>
        /// <returns>
        /// Assignments in dataset
        /// </returns>
        public DataSet GetAssignment()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Assignments", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method FetchAssignment
        /// Get Assignment detail
        /// </summary>
        /// <param name="assignmentId">The assignmentID to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Assignments in dataset
        /// </returns>
        public DataSet FetchAssignment(int assignmentId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Assignments WHERE assignmentID=" + assignmentId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method UpdateAssignment
        /// Update Assignment detail
        /// </summary>
        /// <param name="assignmentId">The assignmentID to update detail</param>
        /// <param name="assignmentName">String new assignmentName</param>
        /// <param name="assignmentDescription">String new assignmentDescription</param>
        /// <param name="courseID">Int new courseID</param>
        /// <remarks></remarks>
        /// <returns>
        /// Boolean true if assignment updated successfully
        /// Boolean false if failed update
        /// </returns>
        public Boolean UpdateAssignment(int assignmentId, string assignmentName, string assignmentDescription, int courseID)
        {
            try
            {
                string sqlQuery = "UPDATE Assignments SET assignmentName = '" + assignmentName + "', assignmentDescription = '" + assignmentDescription + "', courseID = " + courseID + "";
                sqlQuery += " WHERE assignmentID=" + assignmentId;
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
        /// Insert new assignment into database
        /// </summary>
        /// <param name="assignmentName">String new assignmentName</param>
        /// <param name="assignmentDescription">String new assignmentDescription</param>
        /// <param name="courseId">Int new courseID</param>
        /// <remarks>assignmentID is automatically inserted into database</remarks>
        /// <returns>
        /// Boolean true if assignment inserted successfully
        /// Boolean false if failed insertion
        /// </returns>
        public Boolean InsertAssignment(string assignmentName, string assignmentDescription, int courseId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Assignments VALUES ('" + assignmentName + "', '" + assignmentDescription + "', " + courseId + ")", _db.sqlcon);
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
        /// Delete an assignment
        /// </summary>
        /// <param name="assignmentId">Int assignmentId</param>
        public Boolean DeleteAssignment(int assignmentId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE Assignments WHERE assignmentID=" + assignmentId, _db.sqlcon);
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
