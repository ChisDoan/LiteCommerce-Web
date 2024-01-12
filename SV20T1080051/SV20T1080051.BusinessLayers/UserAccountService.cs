using SV20T1080051.DataLayers;
using SV20T1080051.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080051.BusinessLayers
{
    public static class UserAccountService
    {
        private static readonly IUserAccountDAL employeeUserAccountDB;

        /// <summary>
        /// 
        /// </summary>
        static UserAccountService()
        {
            string connectionString = "server=CHIS;Integrated Security=SSPI;database=LiteCommerceDB;TrustServerCertificate=true";
            employeeUserAccountDB = new DataLayers.SQLServer.EmployeeUserAccountDAL(connectionString);
        }

        public static UserAccount? Authorize(string userName, string password, TypeOfAccount typeOfAccount)
        {
            switch (typeOfAccount)
            {
                case TypeOfAccount.Employee:
                    return employeeUserAccountDB.Authorize(userName, password);
                default:
                    return null;
            }
        }
    }

    public enum TypeOfAccount { Employee, UserAccount }
}
