using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : AdmissionManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Admission methods
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 17 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    
    
    public class AdmissionManage
    {
        // Instance DB Connection
        readonly Database _db = new Database();

        /// <summary>
        /// Update admission status
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        public Boolean AcceptAdmission(int admissionId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE OnlineAdmission SET status = 1 WHERE admissionID=" + admissionId, _db.sqlcon);
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
        /// Delete Admission
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        public Boolean DeleteAdmission(int admissionId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE OnlineAdmission WHERE admissionID=" + admissionId, _db.sqlcon);
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
        /// Fetch Student Detail
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        public DataSet FetchStudentDetail(int admissionId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM StudentRegistration WHERE admissionID=" + admissionId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Get Admission Detail by ID
        /// </summary>
        /// <param name="admissionId">Int Admission ID</param>
        /// <returns></returns>
        public DataSet FetchAdmissionDetail(int admissionId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM OnlineAdmission WHERE admissionID="+admissionId+" AND status=0 ORDER BY admissionID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Get Online Admission list
        /// </summary>
        /// <returns></returns>
        public DataSet GetOnlineAdmission()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM OnlineAdmission WHERE status=0 ORDER BY admissionID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Insert student password
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean InsertStudentPassword(int admissionId, string password)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE StudentRegistration SET Password = '" + password + "' WHERE admissionID = " + admissionId, _db.sqlcon);
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
        /// Insert Optional Subkect (course )
        /// Student Registration
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Boolean InsertOptionalSubject(int admissionId, int courseId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("UPDATE StudentRegistration SET optionalSubject = " + courseId + " WHERE admissionID = "+admissionId, _db.sqlcon);
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
        /// Student registration
        /// Insert Specialized Subject - Course
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Boolean InsertSpecializedSubject(int admissionId, int courseId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO StudentRegistration VALUES (" + courseId + ", 0, " + admissionId + ", 0)", _db.sqlcon);
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
        /// Get Student by Admission Id
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns>DataSet Student</returns>
        public DataSet GetStudent(int admissionId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM StudentRegistration WHERE admissionID=" + admissionId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Get Admission ID from string
        /// </summary>
        /// <param name="uniqueId">Unique ID provided to user</param>
        /// <returns>INT admissionID</returns>
        public int GetAdmisionIdFromString(string uniqueId)
        {
            string resultString = Regex.Match(uniqueId, @"\d+").Value;
            return int.Parse(resultString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regkey"></param>
        /// <returns></returns>
        public DataSet GenerateUniqueId(string regkey)
        {
            _db.sqlda = new SqlDataAdapter("SELECT admissionID FROM OnlineAdmission WHERE regKey='" + regkey + "'", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        public DataSet AdmissionStatus(int admissionId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT status FROM OnlineAdmission WHERE admissionID=" + admissionId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="motherName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="resAddress"></param>
        /// <param name="perAddress"></param>
        /// <param name="gender"></param>
        /// <param name="sportDetail"></param>
        /// <param name="admissionFor"></param>
        /// <param name="university"></param>
        /// <param name="enrol"></param>
        /// <param name="center"></param>
        /// <param name="stream"></param>
        /// <param name="field"></param>
        /// <param name="mark"></param>
        /// <param name="outOf"></param>
        /// <param name="classObtained"></param>
        /// <returns></returns>
        public Boolean InsertAdmission(string name, string fatherName, string motherName, string dateOfBirth, string resAddress, string perAddress, int gender, string sportDetail, string university, string enrol, string center, string stream, string field, string mark, string outOf, string classObtained, string regKey, string admissionFor)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO OnlineAdmission VALUES ('" + name + "','" + fatherName + "','" + motherName + "','" + dateOfBirth + "', " + gender + " ,'" + resAddress + "','" + perAddress + "','" + sportDetail + "','" + university + "','" + enrol + "','" + center + "','" + stream + "','" + field + "','" + mark + "','" + outOf + "','" + classObtained + "', '" + regKey + "', 0, '" + admissionFor + "')", _db.sqlcon);
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
