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
    public interface iCreditCardDAL
    {
        void Insert(
            string cardNumber,
            DateTime cardExpiry,
            string cardName,
            int cvvCode,
            string cardType);
        void Update(
            int creditCardID,
            string cardNumber,
            DateTime cardExpiry,
            string cardName,
            int cvvCode,
            string cardType);
        void Delete(int creditCardID);
        DataTable GetData();
        DataTable GetData(int creditCardID);
    }
}
