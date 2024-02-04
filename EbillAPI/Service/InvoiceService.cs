using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EbillAPI.Service
{
    public class InvoiceService
    {
        public object GetInvByInvNoApi(string invoiceNo)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter { ParameterName ="@InvoiceNo", Value= invoiceNo},
                };

                var ds = CommonService.ExecuteStoredProcedureForDS("Sp_GetInvoice", parameters);
                if (ds.Tables.Count > 1)
                {
                    ds.Tables[0].TableName = "InvoiceHeader";
                    ds.Tables[1].TableName = "InvoiceBody";
                    ds.Tables[2].TableName = "PaymentDetails";
                    ds.Tables[3].TableName = "LoyaltyDetails";
                }
                return ds;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}