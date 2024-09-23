using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi05.Models;
using WebApi05.Service;


namespace WebApi05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;   
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students=await studentsRepository.GetAllStudents();
            return Ok(students);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> update(Students model)
        {
            
             var res=await studentsRepository.InserUpdateStudents(model);
            return Ok(res);
        }
        [HttpDelete("Delete/{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var res = await studentsRepository.DeleteStudents(Id);
            return Ok("true");
        }
    }
}
        