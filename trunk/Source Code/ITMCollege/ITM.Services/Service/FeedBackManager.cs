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
    /// Class	 : FeedBackManager
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for FeedBack Manager
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 14 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FeedBackManager
    {
        /*
         * Instance variables
         */
        readonly Database _db = new Database();

        /// <summary>
        /// Delete Feedback from database
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public Boolean DeleteFeedback(int feedbackId)
        {
            try
            {
                _db.sqlda = new SqlDataAdapter("DELETE FeedBacks WHERE feedbackID=" + feedbackId, _db.sqlcon);
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
        /// Retrieve Feedback Content
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public DataSet FetchFeedback(int feedbackId)
        {
            _db.sqlda = new SqlDataAdapter("SELECT FeedBacks.*, Courses.courseName FROM FeedBacks INNER JOIN Courses ON FeedBacks.courseID = Courses.courseID WHERE feedbackID="+feedbackId, _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
        /// <summary>
        /// Retrive feedback list
        /// </summary>
        /// <returns></returns>
        public DataSet GetFeedBack()
        {
            _db.sqlda = new SqlDataAdapter("SELECT FeedBacks.*, Courses.courseName FROM FeedBacks INNER JOIN Courses ON FeedBacks.courseID = Courses.courseID ORDER BY feedbackID DESC", _db.sqlcon);
            _db.ds = new DataSet();
            _db.sqlda.Fill(_db.ds);
            return _db.ds;
        }
    }
}
