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
    public interface iProductRatingDAL
    {
        void Insert(
            int memberID,
            int productID,
            int ratingAmount);
        void Update(
            int memberID,
            int productID,
            int ratingAmount);
        void Delete(
            int memberID,
            int productID);
        DataTable GetData();
        DataTable GetData(int ratingID);
    }
}
