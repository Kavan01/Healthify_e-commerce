using Healthify1.BAL;
using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        [HttpGet("{UserName}/{Password}")]
        public IActionResult Get(string UserName, string Password)
        {
            Login_BALBase bal = new Login_BALBase();
            RegistrationModel login = bal.API_Login_Check(UserName, Password);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (login.UserID != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", login);
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
    }
}
