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
    public interface iGameRatingDAL
    {
        void Insert(
            int ratingAmount,
            int memberID,
            int productID);

        void Update(
            int ratingID,
            int ratingAmount,
            int memberID,
            int productID);

        void Delete(int ratingID);


        DataTable GetData();
        DataTable GetData(int ratingID);
    }
}
