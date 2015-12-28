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
    /// Class	 : FacilitiesManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Facilities Manage
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 23 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FacilitiesManage
    {
         /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Method GetFacilities
        /// </summary>
        /// <remarks></remarks>
        /// <returns>
        /// Facilities in dataset
        /// </returns>
        public DataSet GetFacilities()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Facilities", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method FetchFacilities
        /// Get facilitie detail
        /// </summary>
        /// <param name="facilitieId">The facilitieId to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Facilities in dataset
        /// </returns>
        public DataSet FetchFacilities(int facilitieId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM Facilities WHERE facilitieID=" + facilitieId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method UpdateFacilities
        /// Get Facilities detail
        /// </summary>
        /// <param name="facilitieId">The facilitieID to fetch detail</param>
        /// <param name="facilitieName">String encrypted facilitieName</param>
        /// <param name="facilitieImage">String facilitieImage of facilitie</param>
        /// <param name="facilitieDescription">String  facilitieDescription</param>
        /// <remarks></remarks>
        /// <returns>
        /// Facilities in dataset
        /// </returns>
        public Boolean UpdateFacilities(int facilitieId,string facilitieName, string facilitieImage, string facilitieDescription)
        {
            try
            {
                string sqlQuery = "UPDATE Facilities SET facilitieName = '" + facilitieName + "',facilitieImage ='" + facilitieImage + "',facilitieDescription ='" + facilitieDescription + "'";
            sqlQuery += "WHERE facilitieID=" + facilitieId;
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
        /// Insert new facilitie into database
        /// </summary>
        /// <param name="facilitieName">String  facilitieName</param>
        /// <param name="facilitieImage">String facilitieImage of facilitie</param>
        /// <param name="facilitieDescription">String  facilitieDescription</param>
        /// <returns>Boolean true if facilitie inserted</returns>
        public Boolean InsertFacilities(string facilitieName, string facilitieImage, string facilitieDescription)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO Facilities VALUES ('" + facilitieName + "', '" + facilitieImage + "', '" + facilitieDescription + "')", _db.sqlcon);
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
        /// Delete an Facilities
        /// </summary>
        /// <param name="facilitieId">Int facilities id</param>
        public Boolean DeleteFacilities(int facilitieId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE Facilities WHERE facilitieID=" + facilitieId, _db.sqlcon);
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
