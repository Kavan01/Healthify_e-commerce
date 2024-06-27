using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Healthify1.Models;

namespace Healthify1.DAL
{
    public class Product_DALBase : DAL_Helpers
    {
        #region API_PR_PRODUCT_SELECT_ALL

        public List<ProductModel> API_PR_PRODUCT_SELECT_ALL()
        {
            
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_SELECT_ALL");
                List<ProductModel> productModels = new List<ProductModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        ProductModel productModel = new ProductModel();
                        productModel.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                        /*productModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());*/
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.Price = Convert.ToDecimal(dr["Price"].ToString());
                        productModel.Description = dr["Description"].ToString();
                        productModel.StockQty = Convert.ToInt32(dr["StockQty"].ToString());
                        productModel.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        productModel.Image = dr["Image"].ToString();
                        productModels.Add(productModel);
                    }
                }
                return productModels;
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@ProductID", SqlDbType.Int, ProductID);
                ProductModel productModel = new ProductModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        productModel.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                        /*productModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());*/
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.Price = Convert.ToDecimal(dr["Price"].ToString());
                        productModel.Description = dr["Description"].ToString();
                        productModel.StockQty = Convert.ToInt32(dr["StockQty"].ToString());
                        productModel.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        productModel.Image = dr["Image"].ToString();

                    }
                }
                return productModel;
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@ProductID", SqlDbType.Int, ProductID);
                ProductModel productModel = new ProductModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("MultiDeleteProcedure");
                sqlDatabase.AddInParameter(dbCommand, "@lstid", DbType.String, ProductIDlist);
                ProductModel productModel = new ProductModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", SqlDbType.Int, ProductModel.CategoryID);
                sqlDatabase.AddInParameter(dbCommand, "@ProductName", SqlDbType.VarChar, ProductModel.ProductName);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, ProductModel.Price);
                sqlDatabase.AddInParameter(dbCommand, "@Description", SqlDbType.VarChar, ProductModel.Description);
                sqlDatabase.AddInParameter(dbCommand, "@StockQty", SqlDbType.Int, ProductModel.StockQty);
                sqlDatabase.AddInParameter(dbCommand, "@Quantity", SqlDbType.Int, ProductModel.Quantity);
                sqlDatabase.AddInParameter(dbCommand, "@Image", SqlDbType.VarChar, ProductModel.Image);
                /*ProductModel productModel = new ProductModel();*/
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@ProductID", SqlDbType.Int, ProductModel.ProductID);
                sqlDatabase.AddInParameter(dbCommand, "@ProductName", SqlDbType.VarChar, ProductModel.ProductName);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, ProductModel.Price);
                sqlDatabase.AddInParameter(dbCommand, "@Description", SqlDbType.VarChar, ProductModel.Description);
                sqlDatabase.AddInParameter(dbCommand, "@StockQty", SqlDbType.Int, ProductModel.StockQty);
                sqlDatabase.AddInParameter(dbCommand, "@Quantity", SqlDbType.Int, ProductModel.Quantity);
                sqlDatabase.AddInParameter(dbCommand, "@Image", SqlDbType.VarChar, ProductModel.Image);
                ProductModel productModel = new ProductModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_Category_SelectAll_Dropdown");
                List<CategoryDropdownModel> catModels = new List<CategoryDropdownModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        CategoryDropdownModel catModel = new CategoryDropdownModel();
                        catModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        catModel.CategoryName = dr["CategoryName"].ToString();
                        catModels.Add(catModel);
                    }
                }
                return catModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_PR_PRODUCT_SELECT_ALL

        public List<ProductModel> API_PR_PRODUCT_SELECT_BY_CATEGORY(int CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_PRODUCT_SELECT_BY_CATEGORY");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", SqlDbType.Int, CategoryID);
                List<ProductModel> productModels = new List<ProductModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        ProductModel productModel = new ProductModel();
                        productModel.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                        /*productModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());*/
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.Price = Convert.ToDecimal(dr["Price"].ToString());
                        productModel.Description = dr["Description"].ToString();
                        productModel.StockQty = Convert.ToInt32(dr["StockQty"].ToString());
                        productModel.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        productModel.Image = dr["Image"].ToString();
                        productModels.Add(productModel);
                    }
                }
                return productModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}