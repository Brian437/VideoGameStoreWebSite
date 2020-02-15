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
    public class CartDAL_SQL : iCartDAL
    {
        /// <summary>
        /// inserts values into cart table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="quantiy">quantiy</param>
        /// <param name="productID">product id</param>
        /// <param name="cartStatus">cart status</param>
        /// <param name="sessionID">session id</param>
        /// <param name="price">price of product</param>
        public void Insert(int memberID, int quantiy, int productID, int cartStatus, int sessionID, decimal price)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO cart VALUES ('" +
                "{0},{1},{2},{3},{4},{5});",
                memberID, quantiy,productID, cartStatus, sessionID, price);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Updates the cart item
        /// </summary>
        /// <param name="cartID">cart id to update</param>
        /// <param name="memberID">member id</param>
        /// <param name="quantiy">quantiy</param>
        /// <param name="productID">product id</param>
        /// <param name="cartStatus">cart status</param>
        /// <param name="sessionID">session id</param>
        /// <param name="price">price of product</param>
        public void Update(int cartID, int memberID, int quantiy, int productID, int cartStatus, int sessionID, decimal price)
        {
            Connection.Open();
            string sqlString =
                "UPDATE cart SET " +
                    "member_id =" + memberID.ToString() + ", " +
                    "product_quantiy = " + quantiy.ToString() + ", " +
                    "product_Id = " + productID.ToString() + "," +
                    "cart_status = '" + cartStatus.ToString() + "'," +
                    "session_id = " + sessionID.ToString() + "," +
                    "price = "+price.ToString() +" "+
                "WHERE cart_id = " + cartID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from cart table
        /// </summary>
        /// <param name="cartID">cart id</param>
        public void Delete(int cartID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM cart " +
                "WHERE cartID = " + cartID + ";";
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
        /// gets all the rows from the cart table
        /// </summary>
        /// <returns>all the rows from the cart table</returns>
        public System.Data.DataTable GetData()
        {
            string sqlString =
                "SELECT cart.*, username, product_name " +
                "FROM cart " +
                    "LEFT JOIN member " +
                        "ON member.member_id=cart.member_id " +
                    "LEFT JOIN product " +
                        "ON product.product_id = cart.product_id;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// returns one row from cart table
        /// </summary>
        /// <param name="cartID">cart id</param>
        /// <returns>one row from cart table</returns>
        public System.Data.DataTable GetData(int cartID)
        {
            string sqlString =
                "SELECT cart.*, username, product_name " +
                "FROM cart " +
                    "LEFT JOIN member " +
                        "ON member.member_id=cart.member_id " +
                    "LEFT JOIN product " +
                        "ON product.product_id = cart.product_id "+
                "WHERE cart_id = "+cartID;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
