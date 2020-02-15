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
    class EventMemberRegistration:iEventMemberRegistrationDAL
    {
        /// <summary>
        /// inserts into event_member_registration table
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="eventID">event id</param>
        public void Insert(int memberID, int eventID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO event_member_registration VALUES ({0},{1});",
                memberID, eventID);

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// deletes from event_member_registration
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="eventID">event id</param>
        public void Delete(int memberID, int eventID)
        {
            Connection.Open();
            string sqlString = string.Format(
                "DELETE FROM event_member_registration " +
                "WHERE memberId = {0} "+
                    "AND event_id = {1} ;",

                memberID, eventID);
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
        /// gets all the rows from event_member_registration table
        /// </summary>
        /// <returns>all the rows from event_member_registration table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT emr.* username, event_location " +
                "FROM event_member_registration emr" +
                    "JOIN member " +
                        "ON member.member_id= emr.member_id " +
                    "JOIN event " +
                        "ON event.event_id=emr.event_id;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets all the members based on event id
        /// </summary>
        /// <param name="eventID">event id</param>
        /// <returns>all the members</returns>
        public DataTable GetMembers(int eventID)
        {
            string sqlString =
                "SELECT emr.*, username " +
                "FROM event_member_registration emr" +
                    "JOIN member " +
                    "ON member.member_id= emr.member_id " +
                "WHERE event_id = " + eventID + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets all the events for the member
        /// </summary>
        /// <param name="customerID">member id</param>
        /// <returns>all the events</returns>
        public DataTable GetEvents(int customerID)
        {
            string sqlString =
                "SELECT emr.*  event_location " +
                "FROM event_member_registration emr" +
                    "JOIN event " +
                    "ON event.event_id=emr.event_id " +
                "WHERE member_id = " + customerID + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
