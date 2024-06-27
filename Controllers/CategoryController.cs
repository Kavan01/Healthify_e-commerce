using Microsoft.AspNetCore.Mvc;
using Healthify1.BAL;
using Healthify1.Models;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        #region Get All Categories
        [HttpGet]
        public IActionResult Get()
        {
            Category_BALBase bal = new Category_BALBase();
            List<CategoryModel> cats = bal.API_PR_CATEGORY_SELECT_ALL();
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
                response.Add("status", true);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
        #region Get Categories By ID
        [HttpGet("{CategoryID}")]
        public IActionResult Get(int CategoryID)
        {
            Category_BALBase bal = new Category_BALBase();
            CategoryModel cat = bal.API_PR_CATEGORY_SELECT_BY_PK(CategoryID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (cat.CategoryID != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", cat);
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
        #region Delete
        [HttpDelete]
        public IActionResult Delete(int CategoryID)
        {
            Category_BALBase bal = new Category_BALBase();
            bool IsSuccess = bal.API_PR_CATEGORY_DELETE(CategoryID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion

        #region API_PR_CATEGORY_INSERT
        [HttpPost]
        public IActionResult Insert([FromForm] CategoryModel CategoryModel)
        {
            Category_BALBase bal = new Category_BALBase();
            bool IsSuccess = bal.API_PR_CATEGORY_INSERT(CategoryModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion

        #region API_PR_CATEGORY_UPDATE
        [HttpPut]
        public IActionResult Update(int CategoryID, [FromForm] CategoryModel CategoryModel)
        {
            Category_BALBase bal = new Category_BALBase();
            CategoryModel.CategoryID = CategoryID;
            bool IsSuccess = bal.API_PR_CATEGORY_UPDATE(CategoryID, CategoryModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Some error has been occured.");
                return NotFound(response);
            }
        }
        #endregion
    }
}