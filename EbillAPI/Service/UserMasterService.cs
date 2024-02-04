using EbillAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EbillAPI.Service
{
    public class UserMasterService
    {
        public object Login(string username, string pasword) 
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter { ParameterName ="@InvoiceNo", Value= username},
                   new SqlParameter { ParameterName ="@pasword", Value= username},
                };

                if (username == "admin" & pasword == "admin")
                {
                    return new LoginMapper { UserName = "admin", Password = "admin", UserLevel = 1, CompanyBranchId = 1, CompanyDepartmentId = 1 };
                }
                else
                {
                    return new LoginMapper { UserName = "false", Password = "", UserLevel = 0, CompanyBranchId = 0, CompanyDepartmentId = 0 };
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}