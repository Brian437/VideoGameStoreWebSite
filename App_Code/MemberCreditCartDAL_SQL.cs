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
    public class MemberCreditCartDAL_SQL:iMemberCreditCardDAL
    {
        /// <summary>
        /// Inserts into member_credit_card table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="creditCardID">credit card id</param>
        public void Insert(int memberID, int creditCardID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO member_credit_card VALUES ({0},{1});",
                memberID, creditCardID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// deletes from the member_credit_card table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="creditCardID">credit card id</param>
        public void Delete(int memberID, int creditCardID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM member_credit_card WHERE " +
                "member_Id = " + memberID.ToString() + " AND " +
                "credit_Card_Id = " + creditCardID.ToString() + ";";
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
        /// Gets all the rows from member_credit_card table
        /// </summary>
        /// <returns>all the rows from member_credit_card table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM member_credit_card;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
