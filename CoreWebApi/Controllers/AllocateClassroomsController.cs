using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models;
using CoreWebApi.Repository;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomsController : ControllerBase
    {
        private readonly IAllocateClassroomsRepository _repository;

        public AllocateClassroomsController(IAllocateClassroomsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/AllocateClassrooms
        [HttpGet]
        public IActionResult GetAllAllocateClassrooms()
        {
            var allocateClassrooms = _repository.GetAllAllocateClassrooms();
            return Ok(allocateClassrooms);
        }

        // GET: api/AllocateClassrooms/{id}
        [HttpGet("{id}")]
        public IActionResult GetAllocateClassroomById(int id)
        {
            var allocateClassroom = _repository.GetAllocateClassroomById(id);
            if (allocateClassroom == null)
            {
                return NotFound();
            }
            return Ok(allocateClassroom);
        }

        // POST: api/AllocateClassrooms
        [HttpPost]
        public IActionResult AddAllocateClassroom(AllocateClassroomsModel allocateClassroom)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAllocateClassroom(allocateClassroom);
                return CreatedAtAction(nameof(GetAllocateClassroomById), new { id = allocateClassroom.AllocateClassroomID }, allocateClassroom);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/AllocateClassrooms/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAllocateClassroom(int id, AllocateClassroomsModel allocateClassroom)
        {
            if (id != allocateClassroom.AllocateClassroomID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingAllocateClassroom = _repository.GetAllocateClassroomById(id);
                if (existingAllocateClassroom == null)
                {
                    return NotFound();
                }

                _repository.UpdateAllocateClassroom(allocateClassroom);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/AllocateClassrooms/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAllocateClassroom(int id)
        {
            var allocateClassroom = _repository.GetAllocateClassroomById(id);
            if (allocateClassroom == null)
            {
                return NotFound();
            }

            _repository.DeleteAllocateClassroom(id);
            return NoContent();
        }
    }
}
