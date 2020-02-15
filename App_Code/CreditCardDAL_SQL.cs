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
    public class CreditCardDAL_SQL : iCreditCardDAL
    {
        /// <summary>
        /// Inserts into credit card 
        /// </summary>
        /// <param name="cardNumber">credit card number</param>
        /// <param name="cardExpiry">credit card expirey date</param>
        /// <param name="cardName">name of credit card</param>
        /// <param name="cvvCode">cvv Code</param>
        /// <param name="cardType">card type</param>
        public void Insert(string cardNumber, DateTime cardExpiry, string cardName, int cvvCode, string cardType)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO credit_card VALUES ('" +
                "'{0}','{1}','{2}',{3},'{4}');",
                cardNumber, cardExpiry.ToString(Shared.DATE_FORMAT), cardName, cvvCode,cardType);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates the credit card table
        /// </summary>
        /// <param name="creditCardID">credit card id</param>
        /// <param name="cardNumber">card number</param>
        /// <param name="cardExpiry">credit card expirey date</param>
        /// <param name="cardName">name of credit card</param>
        /// <param name="cvvCode">cvv Code</param>
        /// <param name="cardType">card type</param>
        public void Update(int creditCardID, string cardNumber, DateTime cardExpiry, string cardName, int cvvCode, string cardType)
        {
            Connection.Open();
            string sqlString =
                "UPDATE credit_card SET " +
                    "card_number ='" + cardNumber + "', " +
                    "card_expiry = '" + cardExpiry.ToString(Shared.DATE_FORMAT) + "', " +
                    "card_name = " + cardName + "," +
                    "cvv_code = '" + cvvCode.ToString() + "'," +
                    "card_type = " + cardType.ToString() + " " +
                "WHERE credit_card_id = " + creditCardID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from credit card table
        /// </summary>
        /// <param name="creditCardID">credit card id</param>
        public void Delete(int creditCardID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM credit_card WHERE credit_card_id = " + creditCardID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// sqlConnection
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                return Shared.Connection;
            }
        }

        /// <summary>
        /// Returns all the rows from credit card table
        /// </summary>
        /// <returns>all the rows from credit card table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM credit_card;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets one row from credit card table
        /// </summary>
        /// <param name="creditCardID">credit card id</param>
        /// <returns>one row</returns>
        public DataTable GetData(int creditCardID)
        {
            string sqlString =
                "SELECT * " +
                "FROM credit_card " +
                "WHERE credit_card_id = " + creditCardID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
