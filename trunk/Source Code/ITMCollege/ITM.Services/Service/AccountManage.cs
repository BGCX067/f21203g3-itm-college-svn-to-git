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
    /// Class	 : AccountManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Account Manage
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
    public class AccountManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Method GetAccount
        /// </summary>
        /// <remarks></remarks>
        /// <returns>
        /// Accounts in dataset
        /// </returns>
        public DataSet GetAccount()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Accounts", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method FetchAccount
        /// Get account detail
        /// </summary>
        /// <param name="accountId">The accountID to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Accounts in dataset
        /// </returns>
        public DataSet FetchAccount(int accountId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Accounts WHERE accountID="+accountId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method UpdateAccount
        /// Get account detail
        /// </summary>
        /// <param name="accountId">The accountID to fetch detail</param>
        /// <param name="password">String encrypted password</param>
        /// <param name="role">String role of account</param>
        /// <param name="username">String new username</param>
        /// <remarks></remarks>
        /// <returns>
        /// Accounts in dataset
        /// </returns>
        public Boolean UpdateAccount(int accountId, string username, string password, string role)
        {
            try
            {
                string sqlQuery = "UPDATE Accounts SET username = '"+username+"'";
                if ( !string.IsNullOrEmpty(password) )
                {
                    sqlQuery += ", password='" + password + "'";
                }
                sqlQuery += ", role='"+role+"'";
                sqlQuery += " WHERE accountID=" + accountId;
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
        /// Insert new account into database
        /// </summary>
        /// <param name="password">String encrypted password</param>
        /// <param name="role">String role of account</param>
        /// <param name="username">String new username</param>
        /// <remarks>
        /// - Role: admin
        /// - Role: staff
        /// </remarks>
        /// <returns>Boolean true if account inserted</returns>
        public Boolean InsertAccount(string username, string password, string role)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Accounts VALUES ('"+username+"', '"+password+"', '"+role+"')", _db.sqlcon);
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
        /// Delete an Account
        /// </summary>
        /// <param name="accountId">Int account id</param>
        public Boolean DeleteAccount(int accountId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE Accounts WHERE accountID="+accountId, _db.sqlcon);
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
        /// Change account password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="newPassword">New password tobe update</param>
        public Boolean ChangePassword(string username, string newPassword)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE Accounts SET password='"+newPassword+"' WHERE username='"+username+"'", _db.sqlcon);
                _db.ds = new DataSet();
                _db.sqlda.Fill(_db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean IsDuplicateAccount(string username)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Accounts WHERE username='"+username+"'", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            if (_db.ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if user logged and have role to use function
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <remarks>
        /// - Role: admin
        /// - Role: staff
        /// </remarks>
        public Boolean IsAdmin(string role)
        {
            if (role != "admin")
            {
                return false;
            }
            return true;
        }
    }
}
