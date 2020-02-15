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
    public interface iPlatformDAL
    {
        void Insert(string platformName);
        void Update(int platformID, string platformName);
        void Delete(int platformID);
        DataTable GetData();
        DataTable GetData(int platformID);
    }
}
