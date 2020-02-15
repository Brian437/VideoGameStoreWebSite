/*
 * Brian Chaves
 * December 7,2013
 * DALs
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGS_DAL
{
    public static class Shared
    {
        /// <summary>
        /// Date format used
        /// </summary>
        public const string DATE_FORMAT = "yyyy-MM-dd";

        private static SqlConnection connection;
        /// <summary>
        /// SQL Connection string
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
    }
}
