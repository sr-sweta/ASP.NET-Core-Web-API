using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // https://localhost:44387/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // https://localhost:44387/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            String[] studentNames = new String[] { "Aman", "Arti", "Amar", "Ankit", "Aniket" };

            return Ok(studentNames);
        }
    }
}
