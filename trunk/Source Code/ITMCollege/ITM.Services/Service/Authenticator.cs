using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : Authenticator
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Authenticate methods
    /// And Security
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
    public class Authenticator
    {
        /*
         * Instance variables
         */
        Database db = new Database();
        /// <summary> 
        /// Tests whether sandcastle can handle all c# tags as defined at http://msdn2.microsoft.com/en-us/library/5ast78ax.aspx.
        /// Comments of method "Increment (int step)" include almost all tags.
        /// Method "Swap" is used to test generics tags, such as "typeparam".
        /// <threadsafety static="true" instance="false"/>
        /// </summary>
        public DataSet Login(string username, string password)
        {
            db.sqlda = new SqlDataAdapter("SELECT * FROM Accounts WHERE username = '"+username+"' AND password = '"+password+"'", db.sqlcon);
            db.ds = new DataSet();
            db.sqlda.Fill(db.ds);
            return db.ds;
        }

        /// <summary>
        /// Encrypt password for secuity
        /// </summary>
        /// <param name="originalPassword">Password to encrypt</param>
        /// <remarks></remarks>
        /// <returns>
        /// Encrypted password
        /// </returns>
        public string EncodePassword(string originalPassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(originalPassword));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
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

        /// <summary>
        /// Check if user logged and have role to use function
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <remarks>
        /// - Role: admin
        /// - Role: staff
        /// </remarks>
        public Boolean IsStaff(string role)
        {
            if (role != "staff")
            {
                return false;
            }
            return true;
        }
    }
}
