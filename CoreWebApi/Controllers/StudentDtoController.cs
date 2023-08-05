using CoreWebApi.Dtos;
using CoreWebApi.Models;
using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDtoController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentDtoController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetailsDto>> GetStudentDetails(int id)
        {
            var studentDetails = await _studentRepository.GetStudentDetailsByIdAsync(id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return Ok(studentDetails);
        }
    }
}
