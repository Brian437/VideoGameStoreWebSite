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
    public interface iEventDAL
    {
        void Insert(
            string eventLocation,
            DateTime eventDate,
            string eventDetail);
        void Update(
            int eventID,
            string eventLocation,
            DateTime eventDate,
            string eventDetail);
        void Delete(int eventID);
        DataTable GetData();
        DataTable GetData(int eventID);
    }
}
