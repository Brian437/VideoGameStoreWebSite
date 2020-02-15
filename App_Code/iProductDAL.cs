/*
 * Brian Chaves
 * December 7,2013
 * DALs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CVGS_DAL
{
    //Table known as 'Product'
    public interface iProductDAL
    {
        void Insert(
            string gameTitle,
            int gamePlatformID,
            int publisherID,
            decimal price,
            int categoryID,
            int ESRB_RatingID,
            DateTime releaseDate,
            string description);

        void Update(
            int gameID,
            string gameTitle,
            int gamePlatformID,
            int publisherID,
            decimal price,
            int categoryID,
            int ESRB_RatingID,
            DateTime releaseDate,
            string description);

        void Delete(int gameID);

        //SqlConnection Connection { get; set; }

        DataTable GetData();
        DataTable GetData(int gameID);

    }
}
