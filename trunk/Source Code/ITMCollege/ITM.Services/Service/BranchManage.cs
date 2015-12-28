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
    /// Class	 : BranchManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Branch Manage
    /// </summary>
    /// <remarks>
    /// - Process user login
    /// - Check for permission
    /// - Encrypt password
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BranchManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Method GetBranch
        /// </summary>
        /// <remarks> </remarks>
        /// <returns>
        /// Branches in dataset
        /// </returns>
        public DataSet GetBranch()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Branches ORDER BY brancheID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method FetchBranch
        /// Get Branch detail
        /// </summary>
        /// <param name="branchId">The brancheID to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Branches in dataset
        /// </returns>
        public DataSet FetchBranch(int branchId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Branches WHERE brancheID=" + branchId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method UpdateBranch
        /// Update Branch detail
        /// </summary>
        /// <param name="branchId">The brancheID to fetch detail</param>
        /// <param name="branchName">String new brancheName</param>
        /// <param name="branchAddress">String new brancheAddress</param>
        /// <param name="branchEmail">String new brancheEmail</param>
        /// <param name="branchPhone">String new branchePhone</param>
        /// <param name="branchFax">String new brancheFax</param>
        /// <param name="branchDescription">String new Description</param>
        /// <remarks></remarks>
        /// <returns>
        /// Boolean true if branch updated successfully
        /// Boolean false if failed update
        /// </returns>
        public Boolean UpdateBranch(int branchId, string branchName, string branchAddress, string branchEmail, string branchPhone, string branchFax, string branchDescription)
        {
            try
            {
                string sqlQuery = "UPDATE Branches SET brancheName = '" + branchName + "', brancheAddress = '" + branchAddress + "', brancheEmail = '" + branchEmail + "'";
                sqlQuery += ", branchePhone = '" + branchPhone + "', brancheFax = '" + branchFax + "', Description = '" + branchDescription + "'";
                sqlQuery += " WHERE brancheID=" + branchId;
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
        /// Insert new branch into database
        /// </summary>
        /// <param name="branchName">String new brancheName</param>
        /// <param name="branchAddress">String new brancheAddress</param>
        /// <param name="branchEmail">String new brancheEmail</param>
        /// <param name="branchPhone">String new branchePhone</param>
        /// <param name="branchFax">String new brancheFax</param>
        /// <param name="branchDescription">String new Description</param>
        /// <remarks>brancheID is automatically inserted</remarks>
        /// <returns>
        /// Boolean true if branch inserted successfully
        /// Boolean false if failed insertion
        /// </returns>
        public Boolean InsertBranch(string branchName, string branchAddress, string branchEmail, string branchPhone, string branchFax, string branchDescription)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Branches VALUES ('" + branchName + "', '" + branchAddress + "', '" + branchEmail + "', '" + branchPhone + "', '" + branchFax + "', '" + branchDescription + "')", _db.sqlcon);
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
        /// Delete a branch
        /// </summary>
        /// <param name="branchId">Int brancheId</param>
        public Boolean DeleteBranch(int branchId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE Branches WHERE brancheID=" + branchId, _db.sqlcon);
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
