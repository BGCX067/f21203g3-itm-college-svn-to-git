using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ITM.Services.Service
{
    public class FacultyManage
    {
        readonly Database db = new Database();
        public DataSet GetFaculty()
        {
            db.sqlda = new SqlDataAdapter("SELECT * FROM Faculty WHERE disable =0", db.sqlcon);
            db.ds = new DataSet();
            db.sqlda.Fill(db.ds);
            return db.ds;
        }
        public DataSet FetchFaculty(int facultyID)
        {
            db.sqlda = new SqlDataAdapter("SELECT * FROM Faculty WHERE facultyID=" + facultyID, db.sqlcon);
            db.ds = new DataSet();
            db.sqlda.Fill(db.ds);
            return db.ds;
        }
        public Boolean InsertFaculty(string facultyName, string facultyDescription, int facultyOrder, string facultyImage, int departmentID)
        {
            try
            {
                db.sqlda = new SqlDataAdapter("INSERT INTO Faculty VALUES ('" + facultyName + "','" + facultyDescription + "','" + facultyOrder + "','" + facultyImage + "','"+departmentID+"',0)", db.sqlcon);
                db.ds = new DataSet();
                db.sqlda.Fill(db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean UpdateFaculty(int facultyID, string facultyName, string facultyDescription, int facultyOrder, string facultyImage, int departmentID)
        {

            try
            {
                string sqlQuery = "UPDATE Faculty SET facultytName = '" + facultyName + "' , facultyDescription ='" + facultyDescription + "' , facultyOrder = '" + facultyOrder + "', facultyImage ='" + facultyImage + "',departmentID = '"+departmentID+"'";
                sqlQuery += " WHERE facultytID=" + facultyID;
                db.sqlda = new SqlDataAdapter(sqlQuery, db.sqlcon);
                db.ds = new DataSet();
                db.sqlda.Fill(db.ds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
