using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Models;
using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomController : ControllerBase
    {
        private readonly IAllocateClassroomRepository _allocateClassroomRepository;

        public AllocateClassroomController(IAllocateClassroomRepository allocateClassroomRepository)
        {
            _allocateClassroomRepository = allocateClassroomRepository;
        }

        // GET: api/AllocateClassroom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocateClassroomModel>>> GetAllAllocateClassrooms()
        {
            try
            {
                var allocateClassrooms = await _allocateClassroomRepository.GetAllAllocateClassroomsAsync();
                return Ok(allocateClassrooms);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocate classrooms: {ex.Message}");
            }
        }

        // GET: api/AllocateClassroom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllocateClassroomModel>> GetAllocateClassroomById(int id)
        {
            try
            {
                var allocateClassroom = await _allocateClassroomRepository.GetAllocateClassroomByIdAsync(id);
                if (allocateClassroom == null)
                {
                    return NotFound();
                }

                return Ok(allocateClassroom);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocate classroom by ID: {ex.Message}");
            }
        }

        // POST: api/AllocateClassroom
        [HttpPost]
        public async Task<ActionResult<AllocateClassroomModel>> AddAllocateClassroom(AllocateClassroomModel allocateClassroom)
        {
            try
            {
                var addedAllocateClassroom = await _allocateClassroomRepository.AddAllocateClassroomAsync(allocateClassroom);
                return CreatedAtAction(nameof(GetAllocateClassroomById), new { id = addedAllocateClassroom.AllocateClassroomID }, addedAllocateClassroom);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding allocate classroom: {ex.Message}");
            }
        }

        // PUT: api/AllocateClassroom/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllocateClassroom(int id, AllocateClassroomModel allocateClassroom)
        {
            try
            {
                if (id != allocateClassroom.AllocateClassroomID)
                {
                    return BadRequest();
                }

                var existingAllocateClassroom = await _allocateClassroomRepository.GetAllocateClassroomByIdAsync(id);
                if (existingAllocateClassroom == null)
                {
                    return NotFound();
                }

                await _allocateClassroomRepository.UpdateAllocateClassroomAsync(allocateClassroom);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating allocate classroom: {ex.Message}");
            }
        }

        // DELETE: api/AllocateClassroom/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocateClassroom(int id)
        {
            try
            {
                var deleted = await _allocateClassroomRepository.DeleteAllocateClassroomAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting allocate classroom: {ex.Message}");
            }
        }
    }
}
