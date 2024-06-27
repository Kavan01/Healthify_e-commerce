using Healthify1.BAL;
using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class RegisterController : Controller
    {
        [HttpPost]
        public IActionResult Insert([FromForm] RegistrationModel RegistrationModel)
        {
            Register_BALBase bal = new Register_BALBase();
            bool IsSuccess = bal.API_PR_USER_INSERT(RegistrationModel);
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
    }
}
