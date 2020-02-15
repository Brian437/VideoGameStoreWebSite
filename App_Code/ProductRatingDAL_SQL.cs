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
    public class ProductRatingDAL_SQL : iProductRatingDAL
    {
        /// <summary>
        /// inserts into rating_amount table
        /// </summary>
        /// <param name="ratingAmount">rating amount from 1 to 5</param>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        public void Insert(int memberID, int productID,int ratingAmount)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO product_rating VALUES (" +
                    "{0},{1},{2});",
                memberID, productID, ratingAmount);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates the product_rating table
        /// </summary>
        /// <param name="ratingAmount">rating amount from 1 to 5</param>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        
        public void Update(int memberID, int productID, int ratingAmount)
        {
            Connection.Open();
            string sqlString =
                "UPDATE product_rating SET " +
                    "rating_amount =" + ratingAmount.ToString() + ", " +
                "WHERE member_id = " + memberID + " " +
                    "AND product_id = " + productID + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Deletes from product rating table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        public void Delete(int memberID, int productID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM product_rating " +
                "WHERE member_id = " + memberID + " " +
                    "AND product_id = " + productID + ";";
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
        /// gets all the data from product_rating table
        /// </summary>
        /// <returns>all the data from product_rating table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM product_rating;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets the data from product rating table
        /// </summary>
        /// <param name="ratingID">rating id</param>
        /// <returns>one row</returns>
        public DataTable GetData(int ratingID)
        {
            string sqlString =
                "SELECT * " +
                "FROM product_rating "+
                "WHERE rating_id = " + ratingID+";" ;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
