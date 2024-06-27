using Microsoft.AspNetCore.Mvc;
using Healthify1.BAL;
using Healthify1.Models;

namespace Healthify1.Controllers
{
    [ApiController] // Add this attribute to make it an ApiController
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Dashboard_BALBase bal = new Dashboard_BALBase();
            List<DashboardModel> counts = bal.PR_Healthify_Dashboard_Counts();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (counts != null && counts.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", counts);
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
    }
}