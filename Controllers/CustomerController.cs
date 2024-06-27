using Microsoft.AspNetCore.Mvc;
using Healthify1.BAL;
using Healthify1.Models;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class CustomerController : Controller
    {
        #region Get All Customers
        [HttpGet]
        public IActionResult Get()
        {
            Customer_BALBase bal = new Customer_BALBase();
            List<CustomerModel> custs = bal.API_PR_CUSTOMER_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (custs != null && custs.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", custs);
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
        #region Get Customers By ID
        [HttpGet("{CustomerID}")]
        public IActionResult Get(int CustomerID)
        {
            Customer_BALBase bal = new Customer_BALBase();
            CustomerModel cust = bal.API_PR_CUSTOMER_SELECT_BY_PK(CustomerID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (cust.CustomerID != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", cust);
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
        public IActionResult Delete(int CustomerID)
        {
            Customer_BALBase bal = new Customer_BALBase();
            bool IsSuccess = bal.API_PR_CUSTOMER_DELETE(CustomerID);
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

        #region API_PR_CUSTOMER_INSERT
        [HttpPost]
        public IActionResult Insert([FromForm] CustomerModel CustomerModel)
        {
            Customer_BALBase bal = new Customer_BALBase();
            bool IsSuccess = bal.API_PR_CUSTOMER_INSERT(CustomerModel);
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

        #region API_PR_CUSTOMER_UPDATE
        [HttpPut]
        public IActionResult Update(int CustomerID, [FromForm] CustomerModel CustomerModel)
        {
            Customer_BALBase bal = new Customer_BALBase();
            CustomerModel.CustomerID = CustomerID;
            bool IsSuccess = bal.API_PR_CUSTOMER_UPDATE(CustomerID, CustomerModel);
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