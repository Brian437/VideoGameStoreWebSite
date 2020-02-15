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
    public class FriendDAL_SQL : iFriendsDAL
    {
        /// <summary>
        /// inserts into friend table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="friendID">member id 2</param>
        public void Insert(int memberID, int friendID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO friend VALUES ({0},{1});",
                memberID, friendID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from friend table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="friendID">member id 2</param>
        public void Delete(int memberID, int friendID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "DELETE FROM friend " +
                "WHERE member_Id = {0} AND "+
                    "friend_Id = {1} ;",

                memberID, friendID);
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// sql connection
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                return Shared.Connection;
            }
        }

        /// <summary>
        /// returns all the rows from friends table
        /// </summary>
        /// <returns>all the rows from friends table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM friend;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Gets all the friends of one member
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <returns>list of friends</returns>
        public DataTable GetFriends(int memberID)
        {
            string sqlString =
                "SELECT * " +
                "FROM friend "+
                    "LEFT JOIN member member1 "+
                        "ON friend.member_id=member1.member_id "+
                    "LEFT JOIN member member2 "+
                        "ON member2.member_id=friend_id"+
                "WHERE member_id = "+memberID +";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
