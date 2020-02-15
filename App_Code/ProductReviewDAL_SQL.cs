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
    public class ProductReviewDAL_SQL : iProductReviewDAL
    {
        /// <summary>
        /// inserts into product_review table
        /// </summary>
        /// <param name="reviewText">review message</param>
        /// <param name="approved">approved by which employee</param>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        public void Insert(string reviewText, bool approved, int memberID, int productID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO product_review VALUES (" +
                    "'{0}',{1},{2},{3});",
                reviewText, BoolIntConverter.BoolToInt(approved), memberID, productID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates the product_review table
        /// </summary>
        /// <param name="reviewID">review id</param>
        /// <param name="reviewText">review message</param>
        /// <param name="approved">approved by which employee</param>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        public void Update(int reviewID, string reviewText, bool approved, int memberID, int productID)
        {
            Connection.Open();
            string sqlString =
                "UPDATE product_review SET " +
                    "review_text ='" + reviewText + "', " +
                    "approved = " + BoolIntConverter.BoolToInt(approved) + ", " +
                    "member_id = " + memberID + "," +
                    "product_id ="+productID+" "+
                "WHERE review_id = " + reviewID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        public void Approve(int reviewID)
        {
            Connection.Open();
            string sqlString =
                "UPDATE product_review SET " +
                    "approved = 1 " +
                "WHERE review_id = " + reviewID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from the product_review table
        /// </summary>
        /// <param name="reviewID">review id</param>
        public void Delete(int reviewID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM product_review " +
                "WHERE review_id = " + reviewID + ";";
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
        /// gets all the data from product_review table
        /// </summary>
        /// <returns>all the data from product_review table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT pr.*, username, product_name, platform_name " +
                "FROM product_review pr " +
                    "JOIN member ON member.member_id = pr.member_id " +
                    "JOIN product ON product.product_id = pr.product_id " +
                    "JOIN platform ON product.platform_id = platform.platform_id; ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetApprovedReview(int productID)
        {
            string sqlString =
                "SELECT pr.*, username, product_name, platform_name " +
                "FROM product_review pr " +
                    "JOIN member ON member.member_id = pr.member_id " +
                    "JOIN product ON product.product_id = pr.product_id " +
                    "JOIN platform ON product.platform_id = platform.platform_id "+
                "WHERE approved != 0 " +
                "AND product.product_id = " + productID + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetUnapprovedReview()
        {
            string sqlString =
                "SELECT pr.*, username, product_name, platform_name " +
                "FROM product_review pr " +
                    "JOIN member ON member.member_id = pr.member_id " +
                    "JOIN product ON product.product_id = pr.product_id " +
                    "JOIN platform ON product.platform_id = platform.platform_id " +
                "WHERE approved = 0";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// returns one row from product_review table
        /// </summary>
        /// <param name="reviewID">review id</param>
        /// <returns>returns one row from product_review table</returns>
        public DataTable GetData(int reviewID)
        {
            string sqlString =
                "SELECT pr.*, username, product_name, platform_name " +
                "FROM product_review pr " +
                    "JOIN member ON member.member_id = pr.member_id " +
                    "JOIN product ON product.product_id = pr.product_id " +
                    "JOIN platform ON product.platform_id = platform.platform_id " +
                "WHERE review_id = "+reviewID+";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
