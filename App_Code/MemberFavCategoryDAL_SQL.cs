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
    public class MemberFavCategoryDAL_SQL : iMemberFavCategoryDAL
    {
        /// <summary>
        /// inserts into member_fav_category
        /// </summary>
        /// <param name="categoryID">category id</param>
        /// <param name="memberID">member id</param>
        public void Insert(int categoryID, int memberID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO member_fav_category VALUES ({0},{1});",
                categoryID, memberID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from member ctegory
        /// </summary>
        /// <param name="categoryID">category id</param>
        /// <param name="memberID">member id</param>
        public void Delete(int categoryID, int memberID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM member_fav_category " +
                "WHERE member_id = " + memberID.ToString() + " AND " +
                    "category_Id = " + categoryID.ToString() + ";";
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
        /// gets all the records from member_fav_category table
        /// </summary>
        /// <returns>all the records from member_fav_category table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM member_fav_category;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
