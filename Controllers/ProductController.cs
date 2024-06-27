using Microsoft.AspNetCore.Mvc;
using Healthify1.BAL;
using Healthify1.Models;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        #region Get All Products
        [HttpGet]
        public IActionResult Get()
        {
            Product_BALBase bal = new Product_BALBase();
            List<ProductModel> products = bal.API_PR_PRODUCT_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (products != null && products.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", products);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Get Products By ID
        [HttpGet("{ProductID}")]
        public IActionResult Get(int ProductID)
        {
            Product_BALBase bal = new Product_BALBase();
            ProductModel product = bal.API_PR_PRODUCT_SELECT_BY_PK(ProductID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (product.ProductID != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", product);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
        /*#region Delete
        [HttpDelete]
        public IActionResult Delete(int ProductID)
        {
            Product_BALBase bal = new Product_BALBase();
            bool IsSuccess = bal.API_PR_PRODUCT_DELETE(ProductID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion*/

        #region Delete
        [HttpDelete]
        public IActionResult Delete(string ProductIDlist)
        {
            Product_BALBase bal = new Product_BALBase();
            bool IsSuccess = bal.API_PR_PRODUCT_MULTIPLE_DELETE(ProductIDlist);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion

        #region API_PR_PRODUCT_INSERT
        [HttpPost]
        public IActionResult Insert([FromForm] ProductModel ProductModel)
        {
            Product_BALBase bal = new Product_BALBase();
            bool IsSuccess = bal.API_PR_PRODUCT_INSERT(ProductModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion

        #region API_PR_PRODUCT_UPDATE
        [HttpPut]
        public IActionResult Update(int ProductID, [FromForm] ProductModel ProductModel)
        {
            Product_BALBase bal = new Product_BALBase();
            ProductModel.ProductID = ProductID;
            bool IsSuccess = bal.API_PR_PRODUCT_UPDATE(ProductID, ProductModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion

        #region Get All Categories
        [HttpGet]
        public IActionResult GetCategory()
        {
            Product_BALBase bal = new Product_BALBase();
            List<CategoryDropdownModel> cats = bal.API_PR_Category_SelectAll_Dropdown();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (cats != null && cats.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", cats);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Get Products By Category
        [HttpGet]
        public IActionResult GetProductByCategory(int CategoryID)
        {
            Product_BALBase bal = new Product_BALBase();
            List<ProductModel> products = bal.API_PR_PRODUCT_SELECT_BY_CATEGORY(CategoryID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (products != null && products.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", products);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
    }
}