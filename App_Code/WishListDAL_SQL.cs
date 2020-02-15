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
    public class WishListDAL_SQL:iWishlistItemDAL
    {
        /// <summary>
        /// inserts into whish_list table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="productID">product id</param>
        public void Insert(int memberID, int productID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO wishlist_item VALUES ({0},{1});",
                 memberID, productID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// deletes from the wish_list table
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="productID"></param>
        public void Delete(int memberID, int productID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM wishlist_item " +
                "WHERE member_Id = " + memberID.ToString() + " AND " +
                    "product_Id = " + productID.ToString() + ";";
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
        /// Gets all the rows from the wish_list table
        /// </summary>
        /// <returns>all the rows from the wish_list table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT wishlist.*, product.product_name, " +
                    "first_name, last_name, username "+
                "FROM wishlist_item " +
                    "LEFT JOIN product " +
                        "ON wishlist.product_id = product.product_id " +
                    "LEFT JOIN member " +
                        "ON wishlist.member_id= member.member_id; "; 
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
        /// <summary>
        /// gets all the items based on member id provided
        /// </summary>
        /// <param name="customerID">customer ID</param>
        /// <returns>all the items</returns>
        public DataTable GetItems(int customerID)
        {
            string sqlString =
                "SELECT wishlist_item.*, product_name " +
                "FROM wishlist_item " +
                    "JOIN product " +
                    "ON product.product_id=wishlist_item.product_id " +
                "WHERE member_id = " + customerID + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
