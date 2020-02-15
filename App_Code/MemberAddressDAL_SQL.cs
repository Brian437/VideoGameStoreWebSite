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
    public class MemberAddressDAL_SQL : iMemberAddressDAL
    {
        /// <summary>
        ///  inserts into meber_address table
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <param name="addressID">addressID</param>
        /// <param name="addressTypeID">addressTypeID</param>
        public void Insert(int memberID, int addressID, int addressTypeID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO member_address VALUES ({0},{1},{2});",
                memberID, addressID, addressTypeID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// Updates member_address table
        /// </summary>
        /// <param name="memberID">member ID</param>
        /// <param name="addressID">address ID</param>
        /// <param name="addressTypeID">addressTypeID</param>
        public void Update(int memberID, int addressID, int addressTypeID)
        {
            Connection.Open();
            string sqlString =
                "UPDATE member_address SET " +
                    "address_Type_id =" + addressTypeID.ToString() + " " +
                "WHERE member_id = " + memberID.ToString() + "AND "+
                    "address_id = "+addressID.ToString()+ ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Deletes from the member_address table
        /// </summary>
        /// <param name="memberID">member ID</param>
        /// <param name="addressID">address id</param>
        public void Delete(int memberID, int addressID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM member_address " +
                "WHERE memberID = " + memberID.ToString() + " AND " +
                    "ADDRESS_ID = " + addressID.ToString() + ";";
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
        /// Gets all the rows from member_address table
        /// </summary>
        /// <returns>all the rows from member_address table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM member_address;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets one row from member_address table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="addressID">address id</param>
        /// <returns>one row only</returns>
        public DataTable GetData(int memberID, int addressID)
        {
            string sqlString =
                "SELECT * " +
                "FROM member_address " +
                "WHERE member_id = " + memberID.ToString() + "AND"+
                    "address_id ="+addressID.ToString()+";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
