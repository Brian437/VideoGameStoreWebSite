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
    public interface iMemberFavPlatformDAL
    {
        void Insert(
            int memberID,
            int platformID);
        void Delete(
            int memberID,
            int platformID);
        DataTable GetData();
    }
}
