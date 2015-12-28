using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : Database
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Database
    /// </summary>
    /// <remarks>
    /// Automatic create database connection
    /// </remarks>
    /// <history></history>
    /// -----------------------------------------------------------------------------
    public class Database
    {
        /*
         * Instance variables
         */
        public SqlConnection sqlcon;
        public SqlDataAdapter sqlda;
        public DataSet ds;
        public DataTable dt;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// Contains the functionality to connect to database by configured connection string
        /// Connect to Database for attempts to apply 
        /// all adds, updates and deletes
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// - ConnectionString define in Web.config of ITM.Website Project
        /// - ConnectionString have to define by ITMConnectionString
        /// </remarks>
        /// <history>
        /// - May 14, 2013  Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Database()
        {
            //InitializeComponent();
            sqlcon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ITMConnectionString"].ToString());
        }
    }
}
