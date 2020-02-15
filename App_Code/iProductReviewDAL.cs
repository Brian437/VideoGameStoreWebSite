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
    public interface iProductReviewDAL
    {
        void Insert(
            string reviewText,
            bool approved,
            int memberID,
            int productID);
        void Update(
            int reviewID,
            string reviewText,
            bool approved,
            int memberID,
            int productID);
        void Delete(int reviewID);
        DataTable GetData();
        DataTable GetData(int reviewID);

    }
}
