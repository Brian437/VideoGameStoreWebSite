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
    public interface iEventMemberRegistrationDAL
    {
        void Insert(
            int memberID,
            int eventID);
        void Delete(
            int memberID,
            int eventID);
        DataTable GetData();
    }
}
