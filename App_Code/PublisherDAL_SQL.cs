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
    public class PublisherDAL_SQL:iPublisherDAL
    {
        /// <summary>
        /// Inserts into publisher table
        /// </summary>
        /// <param name="companyName">name of company</param>
        /// <param name="companyContact">company contract</param>
        /// <param name="phone">phone number</param>
        /// <param name="email">email address</param>
        public void Insert(string companyName, string companyContact, string phone, string email)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO publisher VALUES (" +
                    "'{0}','{1}','{2}','{3}');",
                companyName, companyContact, phone, email);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates the publisher table
        /// </summary>
        /// <param name="publisherID">publisher id</param>
        /// <param name="companyName">name of company</param>
        /// <param name="companyContact">company contract</param>
        /// <param name="phone">phone number</param>
        /// <param name="email">email address</param>
        public void Update(int publisherID, string companyName, string companyContact, string phone, string email)
        {
            Connection.Open();
            string sqlString =
                "UPDATE publisher SET " +
                    "company_Name ='" + companyName + "', " +
                    "company_Contact = " + companyContact + ", " +
                    "phone = " + phone + "," +
                    "email =" + email + " " +
                "WHERE publisher_ID = " + publisherID + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from the publisher table
        /// </summary>
        /// <param name="publisherID">publisher id</param>
        public void Delete(int publisherID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM publisher " +
                "WHERE review_id = " + publisherID + ";";
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
        /// gets all the rows from the publisher table
        /// </summary>
        /// <returns>gets all the rows from the publisher table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM publisher;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
        /// <summary>
        /// gets only one row from the publisher table
        /// </summary>
        /// <param name="publisherID">publisher id</param>
        /// <returns>only one row from the publisher table</returns>
        public DataTable GetData(int publisherID)
        {
            string sqlString =
                "SELECT * " +
                "FROM publisher "+
                "WHERE publisher_id = "+publisherID+";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Shared.Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
