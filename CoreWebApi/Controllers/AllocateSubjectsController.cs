using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateSubjectsController : ControllerBase
    {
        private readonly IAllocateSubjectsRepository _allocateSubjectsRepository;

        public AllocateSubjectsController(IAllocateSubjectsRepository allocateSubjectsRepository)
        {
            _allocateSubjectsRepository = allocateSubjectsRepository;
        }

        // GET: api/AllocateSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocateSubjectsModel>>> GetAllAllocations()
        {
            var allocations = await _allocateSubjectsRepository.GetAllAllocationsAsync();
            return Ok(allocations);
        }

        // GET: api/AllocateSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllocateSubjectsModel>> GetAllocationById(int id)
        {
            var allocation = await _allocateSubjectsRepository.GetAllocationByIdAsync(id);
            if (allocation == null)
                return NotFound();

            return Ok(allocation);
        }

        // POST: api/AllocateSubjects
        [HttpPost]
        public async Task<ActionResult<AllocateSubjectsModel>> AddAllocation(AllocateSubjectsModel allocation)
        {
            try
            {
                var addedAllocation = await _allocateSubjectsRepository.AddAllocationAsync(allocation);
                return CreatedAtAction(nameof(GetAllocationById), new { id = addedAllocation.AllocateSubjectID }, addedAllocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/AllocateSubjects/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AllocateSubjectsModel>> UpdateAllocation(int id, AllocateSubjectsModel allocation)
        {
            if (id != allocation.AllocateSubjectID)
                return BadRequest();

            try
            {
                var updatedAllocation = await _allocateSubjectsRepository.UpdateAllocationAsync(allocation);
                if (updatedAllocation == null)
                    return NotFound();

                return Ok(updatedAllocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/AllocateSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocation(int id)
        {
            try
            {
                var isDeleted = await _allocateSubjectsRepository.DeleteAllocationAsync(id);
                if (!isDeleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
