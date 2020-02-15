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
    class DownloadableGameDAL_SQL:iDownloadableGame_DAL
    {
        /// <summary>
        /// Inserts into downloadable games
        /// </summary>
        /// <param name="productID">product id</param>
        /// <param name="fileDownload">filedownload</param>
        public void Insert(int productID, object fileDownload)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// updates downloadable_game table
        /// </summary>
        /// <param name="productID">product id</param>
        /// <param name="fileDownload">file download</param>
        public void Update(int productID, object fileDownload)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes from downloadable game table
        /// </summary>
        /// <param name="productID">product id</param>
        public void Delete(int productID)
        {
            string sqlString = "DELETE FROM downloadable_game WHERE product_id = " + productID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
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
        /// returns all rows from downloadableGames table
        /// </summary>
        /// <returns>all rows from downloadableGames table</returns>
        public System.Data.DataTable GetData()
        {
            string sqlString =
                "SELECT *,product_name " +
                "FROM downloadable_game " +
                    "LEFT JOIN products " +
                        "ON product.product_id=downloadable_game.product_id;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Returns one row from downloadableGames table
        /// </summary>
        /// <param name="productID">product id</param>
        /// <returns>one row from downloadableGames table</returns>
        public System.Data.DataTable GetData(string productID)
        {
            string sqlString =
                "SELECT * ,product_name" +
                "FROM downloadable_game " +
                    "LEFT JOIN products " +
                        "ON product.product_id=downloadable_game.product_id "+
                "WHERE product_id = " + productID +";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
