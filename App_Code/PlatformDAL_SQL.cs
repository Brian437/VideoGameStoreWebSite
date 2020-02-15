/*
 * Brian Chaves
 * December 7,2013
 * DALs
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGS_DAL
{
    public class PlatformDAL_SQL : iPlatformDAL
    {
        /// <summary>
        /// inserts into platform table
        /// </summary>
        /// <param name="platformName">name of platform</param>
        public void Insert(string platformName)
        {
            Connection.Open();
            string sqlString =
                "INSERT INTO platform VALUES (" + platformName + ");";

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates platform record
        /// </summary>
        /// <param name="platformID">platform ID</param>
        /// <param name="platformName">Platform Name</param>
        public void Update(int platformID, string platformName)
        {
            Connection.Open();
            string sqlString =
                "UPDATE platform SET " +
                    "platform_Name =" + platformName + " " +
                "WHERE platform_ID = " + platformID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// Deletes from platform table
        /// </summary>
        /// <param name="platformID">platform id</param>
        public void Delete(int platformID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM platform WHERE " +
                "platform_ID = " + platformID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// connection
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                return Shared.Connection;
            }
        }
        /// <summary>
        /// gets all the record from platform table
        /// </summary>
        /// <returns>all the record from platform table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM platform;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
        /// <summary>
        /// gets only one record from platform table
        /// </summary>
        /// <param name="platformID">platform id</param>
        /// <returns>one record</returns>
        public DataTable GetData(int platformID)
        {
            string sqlString =
                "SELECT * " +
                "FROM platform" +
                "WHERE platform_id =" + platformID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
