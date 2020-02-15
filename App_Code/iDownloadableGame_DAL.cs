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
    interface iDownloadableGame_DAL
    {
        void Insert(int productID, Object fileDownload);
        void Update(int productID, Object fileDownload);
        void Delete(int productID);
        DataTable GetData();
        DataTable GetData(string productID);
    }
}
