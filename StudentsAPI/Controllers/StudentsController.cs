using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController() { }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok("works");
        }
    }
}
