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
    public class ESRB_RatingDAL_SQL : iESRB_RatingDAL
    {
        /// <summary>
        /// inserts into esrb_rating table
        /// </summary>
        /// <param name="ratingName">rating name</param>
        /// <param name="ratingAbbreviation">rating abbreviation</param>
        public void Insert(string ratingName,string ratingAbbreviation)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO esrb_rating VALUES ('{0}','{1}');", ratingName, ratingAbbreviation);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Updates the esrb_rating table
        /// </summary>
        /// <param name="ratingID">rating id</param>
        /// <param name="ratingName">rating name</param>
        /// <param name="ratingAbbreviation">rating abbreviation</param>
        public void Update(int ratingID, string ratingName, string ratingAbbreviation)
        {
            Connection.Open();
            string sqlString =
                "UPDATE esrb_rating SET " +
                    "esrb_Rating_Name ='" + ratingName + "' " +
                    "esrb_Rating_Abbreviation = '" + ratingAbbreviation + "' " +
                "WHERE esrb_Rating_Id = " + ratingID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from esrb_rating
        /// </summary>
        /// <param name="ratingID">rating id</param>
        public void Delete(int ratingID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM esrb_rating WHERE esrb_Rating_Id = " + ratingID.ToString() + ";";
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
        /// returns all the rows from esrb_rating table
        /// </summary>
        /// <returns>all the rows from esrb_rating table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM esrb_rating;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// returns only one row from esrb_rating table
        /// </summary>
        /// <param name="ratingID">rating id</param>
        /// <returns>one row from esrb_rating table</returns>
        public DataTable GetData(int ratingID)
        {
            string sqlString =
                "SELECT * " +
                "FROM esrb_rating " +
                "WHERE esrb_Rating_Id = " + ratingID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
