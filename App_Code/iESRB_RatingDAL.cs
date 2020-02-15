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
    public interface iESRB_RatingDAL
    {
        void Insert(
            string ratingName,
            string ratingAbbreviation);
        void Update(int ratingID,
            string ratingName,
            string ratingAbbreviation);
        void Delete(int ratingID);
        DataTable GetData();
        DataTable GetData(int ratingID);
    }
}
