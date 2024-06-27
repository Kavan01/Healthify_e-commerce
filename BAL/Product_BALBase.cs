using Microsoft.AspNetCore.Mvc;
using Healthify1.DAL;
using Healthify1.Models;

namespace Healthify1.BAL
{
    public class Product_BALBase
    {
        #region API_PR_PRODUCT_SELECT_ALL
        public List<ProductModel> API_PR_PRODUCT_SELECT_ALL()
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                List<ProductModel> productModels = product_DALBase.API_PR_PRODUCT_SELECT_ALL();
                return productModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion


        #region API_PR_PRODUCT_SELECT_BY_PK
        public ProductModel API_PR_PRODUCT_SELECT_BY_PK(int ProductID)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                ProductModel productModels = product_DALBase.API_PR_PRODUCT_SELECT_BY_PK(ProductID);
                return productModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region API_PR_PRODUCT_DELETE
        public bool API_PR_PRODUCT_DELETE(int ProductID)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                if (product_DALBase.API_PR_PRODUCT_DELETE(ProductID))
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

        public bool API_PR_PRODUCT_MULTIPLE_DELETE(string ProductIDlist)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                if (product_DALBase.API_PR_PRODUCT_MULTIPLE_DELETE(ProductIDlist))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #region API_PR_PRODUCT_INSERT
        public bool API_PR_PRODUCT_INSERT(ProductModel ProductModel)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                if (product_DALBase.API_PR_PRODUCT_INSERT(ProductModel))
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

        #region API_PR_PRODUCT_UPDATE
        public bool API_PR_PRODUCT_UPDATE(int ProductID, ProductModel ProductModel)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                if (product_DALBase.API_PR_PRODUCT_UPDATE(ProductID, ProductModel))
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

        #region API_PR_Category_SelectAll_Dropdown
        public List<CategoryDropdownModel> API_PR_Category_SelectAll_Dropdown()
        {
            try
            {
                Product_DALBase cat_DALBase = new Product_DALBase();
                List<CategoryDropdownModel> catModels = cat_DALBase.API_PR_Category_SelectAll_Dropdown();
                return catModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region API_PR_PRODUCT_SELECT_BY_CATEGORY
        public List<ProductModel> API_PR_PRODUCT_SELECT_BY_CATEGORY(int CategoryID)
        {
            try
            {
                Product_DALBase product_DALBase = new Product_DALBase();
                List<ProductModel> productModels = product_DALBase.API_PR_PRODUCT_SELECT_BY_CATEGORY(CategoryID);
                return productModels;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}