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
    public class AddressDAL_SQL:iAddressDAL
    {
        /// <summary>
        /// Inserts address information into database
        /// </summary>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="provinceState">province or state</param>
        /// <param name="country">country</param>
        /// <param name="postalZIP_Code">postal code</param>
        public void Insert(string address, string city, string provinceState, string country, string postalZIP_Code)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO address VALUES ('" +
                "'{0}','{1}','{2}','{3}','{4}');",
                address, city, provinceState, country,postalZIP_Code);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// Updates Address table
        /// </summary>
        /// <param name="addressID">address ID to update</param>
        /// <param name="address">address string</param>
        /// <param name="city">city</param>
        /// <param name="provinceState">province or state</param>
        /// <param name="country">country</param>
        /// <param name="postalZIP_Code">Postal or ZIP Code</param>
        public void Update(int addressID, string address, string city, string provinceState, string country, string postalZIP_Code)
        {
            Connection.Open();
            string sqlString =
                "UPDATE address SET " +
                    "street_address ='" + address + "', " +
                    "city = '" + city + "', " +
                    "province = '" + provinceState + "'," +
                    "country = '" + country + "'," +
                    "postal_Code = '" + postalZIP_Code + "' " +
                "WHERE address_id = " + addressID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Address ID to delete
        /// </summary>
        /// <param name="addressID"></param>
        public void Delete(int addressID)
        {
            Connection.Open();
            string sqlString =
                "DELETE FROM address "+
                "WHERE address_id = " + addressID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// SQL conecction
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                return Shared.Connection;
            }
        }

        /// <summary>
        /// Gets all the rows from address table
        /// </summary>
        /// <returns>all the rows from address table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM address;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Gets one row from address table based on address id
        /// </summary>
        /// <param name="addressID">address id</param>
        /// <returns>one row from address table</returns>
        public DataTable GetData(int addressID)
        {
            string sqlString =
                "SELECT * " +
                "FROM address " +
                "WHERE address_id = " + addressID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
