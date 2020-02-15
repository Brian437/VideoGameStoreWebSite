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
    class Event_DAL_SQL:iEventDAL
    {
        /// <summary>
        /// inserts into event table
        /// </summary>
        /// <param name="eventLocation">event location</param>
        /// <param name="eventDate">event date</param>
        /// <param name="eventDetail">event detail</param>
        public void Insert(string eventLocation, DateTime eventDate, string eventDetail)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO event VALUES ('" +
                "'{0}','{1}','{2}');",
                eventLocation, eventDate.ToString(Shared.DATE_FORMAT), eventDetail);
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        /// <summary>
        /// updates the event table
        /// </summary>
        /// <param name="eventID">event id</param>
        /// <param name="eventLocation">event location</param>
        /// <param name="eventDate">event date</param>
        /// <param name="eventDetail">event detail</param>
        public void Update(int eventID, string eventLocation, DateTime eventDate, string eventDetail)
        {
            Connection.Open();
            string sqlString =
                "UPDATE event SET " +
                    "event_location ='" + eventLocation + "', " +
                    "event_date = '" + eventDate.ToString(Shared.DATE_FORMAT) + "', " +
                    "event_detail = '" + eventDetail + "', " +
                "WHERE event_id = " + eventID + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Deletes from the event table
        /// </summary>
        /// <param name="eventID">event id</param>
        public void Delete(int eventID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM event WHERE event_id = " + eventID + ";";
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
        /// gets all rows from event table
        /// </summary>
        /// <returns>all rows from event table</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT * " +
                "FROM event;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets only one row from event table
        /// </summary>
        /// <param name="eventID">event id</param>
        /// <returns>one row based on event id</returns>
        public DataTable GetData(int eventID)
        {
            string sqlString =
                "SELECT * " +
                "FROM event " +
                "WHERE event_id = " + eventID + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
