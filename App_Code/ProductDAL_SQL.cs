/*
 * Brian Chaves
 * December 7,2013
 * DALs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CVGS_DAL
{
    public class ProductDAL_SQL : iProductDAL 
    {
        /// <summary>
        /// inserts a row into the product(game) table
        /// </summary>
        /// <param name="gameTitle">game title</param>
        /// <param name="gamePlatformID">platform id</param>
        /// <param name="publisherID">publisher id</param>
        /// <param name="price">price of the game</param>
        /// <param name="categoryID">category id</param>
        /// <param name="ESRB_RatingID">ESRB rating id</param>
        /// <param name="releaseDate">date of release</param>
        
        public void Insert(string gameTitle, int gamePlatformID, int publisherID, decimal price, int categoryID, int ESRB_RatingID, DateTime releaseDate,string description)
        {
            Connection.Open();
            string releaseDateString;
            if (releaseDate.Year != 1)
            {
                releaseDateString = "'" + releaseDate.ToString(Shared.DATE_FORMAT) + "'";
            }
            else
            {
                releaseDateString = "NULL";
            }

            string sqlString = string.Format(
                "INSERT INTO product VALUES (" +
                "'{0}',{1},{2},{3},{4},{5},{6},'{7}');",

                gameTitle, gamePlatformID.ToString(), publisherID.ToString(), price,
                categoryID.ToString(), ESRB_RatingID.ToString(), releaseDateString,description);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// updates the row in product(game) table
        /// </summary>
        /// <param name="gameID">game id</param>
        /// <param name="gameTitle">game title</param>
        /// <param name="gamePlatformID">platform id</param>
        /// <param name="publisherID">publisher id</param>
        /// <param name="price">price of the game</param>
        /// <param name="categoryID">category id</param>
        /// <param name="ESRB_RatingID">ESRB rating id</param>
        /// <param name="releaseDate">date of release</param>
        public void Update(int gameID, string gameTitle, int gamePlatformID, int publisherID, decimal price, int categoryID, int ESRB_RatingID, DateTime releaseDate,string description)
        {
            Connection.Open();
            string releaseDateString;
            if (releaseDate.Year != 1)
            {
                releaseDateString = "'" + releaseDate.ToString(Shared.DATE_FORMAT) + "'";
            }
            else
            {
                releaseDateString="NULL";
            }

            string sqlString =
                "UPDATE product SET " +
                    "product_Name ='" + gameTitle + "', " +
                    "platform_Id = " + gamePlatformID.ToString() + ", " +
                    "publisher_Id = " + publisherID.ToString() + "," +
                    "price = " + price.ToString() + "," +
                    "category_Id = " + categoryID.ToString() + ", " +
                    "esrbRating_Id = " + ESRB_RatingID.ToString() + ", " +
                    "release_Date = " + releaseDateString + ", " +
                    "description = '"+ description+"' "+
                "WHERE product_Id = " + gameID.ToString() + "; ";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Deletes 
        /// </summary>
        /// <param name="gameID"></param>
        public void Delete(int gameID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM product WHERE product_id = " + gameID.ToString() + ";";
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
        /// gets all the rows from the product table
        /// </summary>
        /// <returns>all the rows from the product table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT product.*, platform_name, ESRB_Rating_name,company_name, category_name, " +
                        "(SELECT AVG(rating_amount) " +
                        "FROM product_rating " +
                        "GROUP BY product_rating.product_id " +
                        "HAVING product_rating.product_id=product.product_id) " +
                    "AS 'rating' " +
                "FROM product  " +
                    "LEFT JOIN platform " +
                        "ON platform.platform_id=product.platform_id " +
                    "LEFT JOIN ESRB_Rating " +
                        "ON esrb_rating_id = esrbRating_id " +
                    "LEFT JOIN publisher " +
                        "ON publisher.publisher_id = product.publisher_id " +
                    "LEFT JOIN category " +
                        "ON category.category_id=product.category_id;";


            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;

        }

        /// <summary>
        /// gets one row from the product table based on game id provided
        /// </summary>
        /// <param name="gameID">game id</param>
        /// <returns>one row</returns>
        public DataTable GetData(int gameID)
        {
            string sqlString =
                "SELECT product.*, platform_name, ESRB_Rating_name,company_name, category_name, " +
                        "(SELECT AVG(rating_amount) " +
                        "FROM product_rating " +
                        "GROUP BY product_rating.product_id " +
                        "HAVING product_rating.product_id=product.product_id) " +
                    "AS 'rating' " +
                "FROM product  " +
                    "LEFT JOIN platform " +
                        "ON platform.platform_id=product.platform_id " +
                    "LEFT JOIN ESRB_Rating " +
                        "ON esrb_rating_id = esrbRating_id " +
                    "LEFT JOIN publisher " +
                        "ON publisher.publisher_id = product.publisher_id " +
                    "LEFT JOIN category " +
                        "ON category.category_id=product.category_id "+
                "WHERE product_id = "+gameID.ToString()+";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable SearchGame(string searchString)
        {
            string sqlString =
                "SELECT product.*, platform_name, ESRB_Rating_name,company_name, category_name, " +
                        "(SELECT AVG(rating_amount) " +
                        "FROM product_rating " +
                        "GROUP BY product_rating.product_id " +
                        "HAVING product_rating.product_id=product.product_id) " +
                    "AS 'rating' " +
                "FROM product  " +
                    "LEFT JOIN platform " +
                        "ON platform.platform_id=product.platform_id " +
                    "LEFT JOIN ESRB_Rating " +
                        "ON esrb_rating_id = esrbRating_id " +
                    "LEFT JOIN publisher " +
                        "ON publisher.publisher_id = product.publisher_id " +
                    "LEFT JOIN category " +
                        "ON category.category_id=product.category_id " +
                "WHERE (CONCAT(product_name,platform_name,ESRB_Rating_name,company_name,category_name,description)) "+
                    "LIKE '%" + searchString + "%' ;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
