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
    public interface iMemberFavCategoryDAL
    {
        void Insert(
            int categoryID,
            int memberID);
        void Delete(
            int categoryID,
            int memberID);
        DataTable GetData();
    }
}
