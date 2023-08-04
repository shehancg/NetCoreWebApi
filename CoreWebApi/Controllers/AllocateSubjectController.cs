using CoreWebApi.Models;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllocateSubjectController : ControllerBase
    {
        private readonly IAllocateSubjectRepository _allocateSubjectRepository;

        public AllocateSubjectController(IAllocateSubjectRepository allocateSubjectRepository)
        {
            _allocateSubjectRepository = allocateSubjectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllocatedSubjects()
        {
            try
            {
                var allocatedSubjects = await _allocateSubjectRepository.GetAllAllocatedSubjectsAsync();
                return Ok(allocatedSubjects);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocated subjects: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllocatedSubjectById(int id)
        {
            try
            {
                var allocateSubject = await _allocateSubjectRepository.GetAllocatedSubjectByIdAsync(id);
                if (allocateSubject == null)
                    return NotFound();

                return Ok(allocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocated subject: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAllocatedSubject(AllocateSubjectModel allocateSubject)
        {
            try
            {
                var newAllocateSubject = await _allocateSubjectRepository.AddAllocatedSubjectAsync(allocateSubject);
                return CreatedAtAction(nameof(GetAllocatedSubjectById), new { id = newAllocateSubject.AllocateSubjectID }, newAllocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding allocated subject: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllocatedSubject(int id, AllocateSubjectModel allocateSubject)
        {
            try
            {
                if (id != allocateSubject.AllocateSubjectID)
                    return BadRequest("Mismatched AllocateSubjectID in the request.");

                var existingAllocateSubject = await _allocateSubjectRepository.GetAllocatedSubjectByIdAsync(id);
                if (existingAllocateSubject == null)
                    return NotFound();

                var updatedAllocateSubject = await _allocateSubjectRepository.UpdateAllocatedSubjectAsync(allocateSubject);
                return Ok(updatedAllocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating allocated subject: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocatedSubject(int id)
        {
            try
            {
                var deleted = await _allocateSubjectRepository.DeleteAllocatedSubjectAsync(id);
                if (!deleted)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting allocated subject: {ex.Message}");
            }
        }
    }
}
