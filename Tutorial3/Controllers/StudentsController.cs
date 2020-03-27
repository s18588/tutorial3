using System;
using Microsoft.AspNetCore.Mvc;
using Tutorial3.Models;

namespace Tutorial3.Controllers
{
    [ApiController]
    [Route("api/students")]

    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string getStudent(String orderby)
        {
            return $"Kowalski, Malewski, Andrzejewski sort={orderby}";
        }
        

        [HttpPost]
        public IActionResult CreateStudent()
        {
            var s = new Student();
            s.IndexNumber = $"s{new Random().Next(1, 2000)}";
            s.IdStudent = 1;
            s.FirstName = "A";
            s.LastName = "B";
            return Ok(s);
        }

        [HttpPut]
        public IActionResult putStudent()
        {
            var s = new Student();
            s.IndexNumber = $"s{new Random().Next(1, 2000)}";
            s.IdStudent = 1;
            s.FirstName = "A";
            s.LastName = "B";
            return Ok(s);
        }

        [HttpDelete]
        public IActionResult removeStudent(int id)
        {
            
            return Ok(id);
        }
    }
}