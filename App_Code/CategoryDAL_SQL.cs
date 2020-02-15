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
    public class CategoryDAL_SQL : iCategoryDAL
    {
        /// <summary>
        /// inserts into category table
        /// </summary>
        /// <param name="categoryName">name of category</param>
        public void Insert(string categoryName)
        {
            Connection.Open();
            string sqlString = "INSERT INTO category VALUES ('" + categoryName + "');";

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Updates the category table table
        /// </summary>
        /// <param name="categoryID">category id</param>
        /// <param name="categoryName">category name to change</param>
        public void Update(string categoryID, string categoryName)
        {
            Connection.Open();
            string sqlString =
                "UPDATE category SET " +
                    "category_name ='" + categoryName + "' " +
                "WHERE category_id = " + categoryID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from category table
        /// </summary>
        /// <param name="categoryID">category id</param>
        public void Delete(string categoryID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM product WHERE category_id = " + categoryID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// SqlConnection
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                return Shared.Connection;
            }
        }

        /// <summary>
        /// Gets all the rows from category table
        /// </summary>
        /// <returns>all the rows from category table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM category;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Gets one row from the category table
        /// </summary>
        /// <param name="categoryID">category id to search</param>
        /// <returns>the one row</returns>
        public DataTable GetData(string categoryID)
        {
            string sqlString =
                "SELECT * " +
                "FROM category " +
                "WHERE category_id = " + categoryID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
