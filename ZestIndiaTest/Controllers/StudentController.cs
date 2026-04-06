using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZestIndiaTest.Models;
using ZestIndiaTest.StudentServices;
using ZestIndiaTest.StudentServices.Interface;

namespace ZestIndiaTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
            => Ok(await _service.Add(student));

        [HttpPut]
        public async Task<IActionResult> Put(Student student)
            => Ok(await _service.Update(student));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
