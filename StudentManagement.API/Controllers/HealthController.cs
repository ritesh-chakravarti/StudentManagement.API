using Microsoft.AspNetCore.Mvc;
namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Status = "Healthy",
                Message = "Student Management API is running successfully."
            });
        }
    }
}