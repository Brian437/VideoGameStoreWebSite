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
    public interface iCategoryDAL
    {
        void Insert(string categoryName);
        void Update(string categoryID,string categoryName);
        void Delete(string categoryID);
        DataTable GetData();
        DataTable GetData(string categoryID);
    }
}
