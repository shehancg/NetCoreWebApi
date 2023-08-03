using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;

namespace CoreWebApi.Repository.Impl
{
    public class AllocateSubjectsRepository : IAllocateSubjectsRepository
    {
        private readonly SchoolManagementContext _context;

        public AllocateSubjectsRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllocateSubjectsModel>> GetAllAllocationsAsync()
        {
            return await _context.AllocateSubjects.ToListAsync();
        }

        public async Task<AllocateSubjectsModel> GetAllocationByIdAsync(int allocateSubjectId)
        {
            return await _context.AllocateSubjects.FindAsync(allocateSubjectId);
        }

        public async Task<AllocateSubjectsModel> AddAllocationAsync(AllocateSubjectsModel allocation)
        {
            _context.AllocateSubjects.Add(allocation);
            await _context.SaveChangesAsync();
            return allocation;
        }

        public async Task<AllocateSubjectsModel> UpdateAllocationAsync(AllocateSubjectsModel allocation)
        {
            _context.AllocateSubjects.Update(allocation);
            await _context.SaveChangesAsync();
            return allocation;
        }

        public async Task<bool> DeleteAllocationAsync(int allocateSubjectId)
        {
            var allocation = await _context.AllocateSubjects.FindAsync(allocateSubjectId);
            if (allocation == null)
                return false;

            _context.AllocateSubjects.Remove(allocation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
