using Microsoft.AspNetCore.Mvc;
using Healthify1.DAL;
using Healthify1.Models;

namespace Healthify1.BAL
{
    public class Customer_BALBase
    {
        #region API_PR_CUSTOMER_SELECT_ALL
        public List<CustomerModel> API_PR_CUSTOMER_SELECT_ALL()
        {
            try
            {
                Customer_DALBase cust_DALBase = new Customer_DALBase();
                List<CustomerModel> custModels = cust_DALBase.API_PR_CUSTOMER_SELECT_ALL();
                return custModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region API_PR_CUSTOMER_SELECT_BY_PK
        public CustomerModel API_PR_CUSTOMER_SELECT_BY_PK(int CustomerID)
        {
            try
            {
                Customer_DALBase cust_DALBase = new Customer_DALBase();
                CustomerModel custModels = cust_DALBase.API_PR_CUSTOMER_SELECT_BY_PK(CustomerID);
                return custModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_DELETE
        public bool API_PR_CUSTOMER_DELETE(int CustomerID)
        {
            try
            {
                Customer_DALBase cust_DALBase = new Customer_DALBase();
                if (cust_DALBase.API_PR_CUSTOMER_DELETE(CustomerID))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_INSERT
        public bool API_PR_CUSTOMER_INSERT(CustomerModel CustomerModel)
        {
            try
            {
                Customer_DALBase cust_DALBase = new Customer_DALBase();
                if (cust_DALBase.API_PR_CUSTOMER_INSERT(CustomerModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_UPDATE
        public bool API_PR_CUSTOMER_UPDATE(int CustomerID, CustomerModel CustomerModel)
        {
            try
            {
                Customer_DALBase cust_DALBase = new Customer_DALBase();
                if (cust_DALBase.API_PR_CUSTOMER_UPDATE(CustomerID, CustomerModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}