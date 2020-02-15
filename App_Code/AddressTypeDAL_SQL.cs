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
    public class AddressTypeDAL_SQL : iAddressTypeDAL
    {
        /// <summary>
        /// Insert into address_Type table
        /// </summary>
        /// <param name="addressTypeName">addrress_type table name</param>
        public void Insert(string addressTypeName)
        {
            Connection.Open();
            string sqlString = "INSERT INTO Address_Type VALUES ('" + addressTypeName + "');";

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// Updates address_type table
        /// </summary>
        /// <param name="addressTypeID">address_type id</param>
        /// <param name="addressTypeName">address type name to update</param>
        public void Update(int addressTypeID, string addressTypeName)
        {
            Connection.Open();
            string sqlString =
                "UPDATE Address_Type SET " +
                    "address_Type_Name ='" + addressTypeName + "' " +
                "WHERE address_Type_Id = " + addressTypeID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Delete from address_type table
        /// </summary>
        /// <param name="addressTypeID">address_type id</param>
        public void Delete(int addressTypeID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM Address_Type " +
                "WHERE Address_Type = " + addressTypeID.ToString() + ";";
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
        /// Gets all the rows from address_type table
        /// </summary>
        /// <returns>all the rows from address_type table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM address_Type;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Gets one row from address_type table bases on address_type id
        /// </summary>
        /// <param name="addressTypeID"></param>
        /// <returns>row</returns>
        public DataTable GetData(int addressTypeID)
        {
            string sqlString =
                "SELECT * " +
                "FROM address_Type " +
                "WHERE address_Type_Id = " + addressTypeID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
