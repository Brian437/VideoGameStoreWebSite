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
    public class MemberFavPlatformDAL_SQL : iMemberFavPlatformDAL
    {
        /// <summary>
        /// inserts  into member_fav_platform table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="platformID">platform id</param>
        public void Insert(int memberID, int platformID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO member_fav_platform VALUES ({0},{1});",
                 memberID,platformID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from member_fav_platform table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="platformID">platform id</param>
        public void Delete(int memberID, int platformID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM member_fav_platform " +
                "WHERE member_id = " + memberID.ToString() + " AND " +
                    "platform_id = " + platformID.ToString() + ";";
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
        /// gets all the rows from member_fav_platform table
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM member_fav_platform;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
