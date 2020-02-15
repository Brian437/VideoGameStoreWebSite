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
    public class MemberDAL_SQL : iMemberDAL
    {
        /// <summary>
        /// Inserts into member table
        /// </summary>
        /// <param name="firstName">fist name</param>
        /// <param name="lastName">last name</param>
        /// <param name="userName">username</param>
        /// <param name="phone">phone number</param>
        /// <param name="email">email address</param>
        /// <param name="memberType">member type id</param>
        /// <param name="isLocked">is the account locked</param>
        /// <param name="passwordAttemptCount">password attept count</param>
        /// <param name="promotionalEmails">subscripts to promotional emails</param>
        /// <param name="lastLoginAttempt">time of last log in attempt</param>
        public void Inseret(string firstName, string lastName, string userName, string phone, string email,
            string memberType, bool isLocked, int passwordAttemptCount, bool promotionalEmails, DateTime lastLoginAttempt)
        {
            Connection.Open();
            string sqlString = string.Format(
                "INSERT INTO member VALUES (" +
                    "'{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},'{9}');",
                firstName, lastName, userName, phone, email, memberType, isLocked, passwordAttemptCount,
                promotionalEmails, lastLoginAttempt.ToString(Shared.DATE_FORMAT));

            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Updates the member record
        /// </summary>
        /// <param name="memberID">member id to update</param>
        /// <param name="firstName">fist name</param>
        /// <param name="lastName">last name</param>
        /// <param name="userName">username</param>
        /// <param name="phone">phone number</param>
        /// <param name="email">email address</param>
        /// <param name="memberType">member type id</param>
        /// <param name="isLocked">is the account locked</param>
        /// <param name="passwordAttemptCount">password attept count</param>
        /// <param name="promotionalEmails">subscripts to promotional emails</param>
        /// <param name="lastLoginAttempt">time of last log in attempt</param>
        public void Update(int memberID, string firstName, string lastName, string userName, string phone,
            string email, string memberType, bool isLocked, int passwordAttemptCount, bool promotionalEmails,
            DateTime lastLoginAttempt)
        {
            Connection.Open();
            string sqlString =
                "UPDATE member SET " +
                    "frist_name ='" + firstName + "', " +
                    "last_name = '" + lastName + "', " +
                    "username = '" + userName + "'," +
                    "phone = '" + phone + "'," +
                    "email = '" + email+ "'," +
                    "member_type '= '" + memberType + "', " +
                    "is_locked = '" + isLocked.ToString() + "', " +
                    "password_attempt_count = "+passwordAttemptCount.ToString()+", "+
                    "promotional_emails =" + promotionalEmails + " " +
                "WHERE member_id = " + memberID.ToString() + ";";
            SqlCommand command = new SqlCommand(sqlString, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// delete member from database
        /// </summary>
        /// <param name="memberID">member id</param>
        public void Delete(int memberID)
        {
            Connection.Open();
            string sqlString = "DELETE FROM member WHERE " +
                "member_id = " + memberID.ToString() + ";";
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
        /// gets all the rows from member database
        /// </summary>
        /// <returns>all the rows from member database</returns>
        public DataTable GetData()
        {
            string sqlString =
                "SELECT member.*,member_type.role " +
                "FROM member "+
                    "LEFT JOIN member_type "+
                    "ON member_type=member_type_id;";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets member based on member id
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <returns>member record</returns>
        public DataTable GetData(int memberID)
        {
            string sqlString =
                "SELECT member.*,member_type.role " +
                "FROM member " +
                    "LEFT JOIN member_type " +
                    "ON member_type=member_type_id "+
                "WHERE member_id = " + memberID.ToString() + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// gets member record based on username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns></returns>
        public DataTable GetData(string username)
        {
            string sqlString =
                "SELECT member.*,member_type.role " +
                "FROM member " +
                    "LEFT JOIN member_type " +
                    "ON member_type=member_type_id " +
                "WHERE username = " + username + ";";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetEmployee()
        {
            string sqlString =
                "SELECT member.*,member_type.role " +
                "FROM member " +
                    "LEFT JOIN member_type " +
                    "ON member_type=member_type_id " +
                "WHERE member_type.role = 'EMPLOYEE' " +
                    "OR member_type.role = 'ADMIN' ;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAdmin()
        {
            string sqlString =
                "SELECT member.*,member_type.role " +
                "FROM member " +
                    "LEFT JOIN member_type " +
                    "ON member_type=member_type_id " +
                "WHERE member_type.role = 'ADMIN' ;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            return dataTable;
        }


    }
}
