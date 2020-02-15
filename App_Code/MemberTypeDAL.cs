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
    public class MemberTypeDAL : iMemberTypeDAL
    {
        /// <summary>
        /// inserts into member_type table
        /// </summary>
        /// <param name="positionName">name of position</param>
        public void Insert(string positionName)
        {
            Connection.Open();
            string sqlString = 
                "INSERT INTO member_type VALUES (" +positionName+");";

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates member_type position
        /// </summary>
        /// <param name="positionID">position id</param>
        /// <param name="positionName">position name</param>
        public void Update(int positionID, string positionName)
        {
            Connection.Open();
            string sqlString = "UPDATE member_type SET " +
                "role =" + positionName + " " +
                "WHERE member_type_id = " + positionID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// deletes from member_type
        /// </summary>
        /// <param name="positionID">position id</param>
        public void Delete(int positionID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM member_type WHERE " +
                "member_type_id = " + positionID.ToString() + ";";
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
        /// gets all the rows from member_type table
        /// </summary>
        /// <returns>all the rows from member_type table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM member_type;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// returns one row from member_type table
        /// </summary>
        /// <param name="PositionID">position</param>
        /// <returns>one row from member_type table</returns>
        public DataTable GetData(int PositionID)
        {
            string sqlString =
                "SELECT * " +
                "FROM member_type " +
                "WHERE member_type_id = " + PositionID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
