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
    /// Class	 : ContentManage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Content Manage
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ContentManage
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataSet GetContentByCategory(string category)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM CollegeContents WHERE contentCategory='"+category+"' ORDER BY contentID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Method GetContent
        /// </summary>
        /// <remarks> </remarks>
        /// <returns>
        /// Contents in dataset
        /// </returns>
        public DataSet GetContent()
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM CollegeContents ORDER BY contentID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method FetchContent
        /// Get Content detail
        /// </summary>
        /// <param name="contentId">The contentID to fetch detail</param>
        /// <remarks></remarks>
        /// <returns>
        /// Contents in dataset
        /// </returns>
        public DataSet FetchContent(int contentId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT * FROM CollegeContents WHERE contentID=" + contentId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }

        /// <summary>
        /// Method UpdateContent
        /// Update Content detail
        /// </summary>
        /// <param name="contentId">The contentID to fetch detail</param>
        /// <param name="contentTitle">String new contentTitle</param>
        /// <param name="contentImage">String new contentImage</param>
        /// <param name="contentText">String new contentText</param>
        /// <param name="contentCategory">String new contentCategory</param>
        /// <remarks></remarks>
        /// <returns>
        /// Boolean true if content updated successfully
        /// Boolean false if failed update
        /// </returns>
        public Boolean UpdateContent(int contentId, string contentTitle, string contentImage, string contentText, string contentCategory)
        {
            try
            {
                string sqlQuery = "UPDATE CollegeContents SET contentTitle = '" + contentTitle + "', contentImage = '" + contentImage + "', contentText = '" + contentText + "', contentCategory = '" + contentCategory + "'";
                sqlQuery += " WHERE contentID=" + contentId;
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
        /// Insert new content into database
        /// </summary>
        /// <param name="contentTitle">String new contentTitle</param>
        /// <param name="contentImage">String new contentImage</param>
        /// <param name="contentText">String new contentText</param>
        /// <param name="contentCategory">String new contentCategory</param>
        /// <remarks>contentID is automatically inserted into database</remarks>
        /// <returns>
        /// Boolean true if content inserted successfully
        /// Boolean false if failed insertion
        /// </returns>
        public Boolean InsertContent(string contentTitle, string contentImage, string contentText, string contentCategory)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("INSERT INTO CollegeContents VALUES ('" + contentTitle + "', '" + contentImage + "', '" + contentText + "', '" + contentCategory + "')", _db.sqlcon);
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
        /// Delete a content
        /// </summary>
        /// <param name="contentId">Int contentId</param>
        public Boolean DeleteContent(int contentId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE CollegeContents WHERE contentID=" + contentId, _db.sqlcon);
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
