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
    public interface iCartDAL
    {
        void Insert(
            int memberID,
            int quantiy,
            int productID,
            int cartStatus,
            int sessionID,
            decimal price);
        void Update(
            int cartID,
            int memberID,
            int quantiy,
            int productID,
            int cartStatus,
            int sessionID,
            decimal price);
        void Delete(int cartID);
        DataTable GetData();
        DataTable GetData(int cartID);
    }
}
