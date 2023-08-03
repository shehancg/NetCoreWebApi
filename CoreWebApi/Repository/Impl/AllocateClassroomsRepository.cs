using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;

namespace CoreWebApi.Repository.Impl
{
    public class AllocateClassroomsRepository : IAllocateClassroomsRepository
    {
        private readonly SchoolManagementContext _context;

        public AllocateClassroomsRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllocateClassroomsModel>> GetAllAllocateClassrooms()
        {
            return await _context.AllocateClassrooms.ToListAsync();
        }

        public async Task<AllocateClassroomsModel> GetAllocateClassroomById(int allocationId)
        {
            return await _context.AllocateClassrooms.FindAsync(allocationId);
        }

        public async Task<AllocateClassroomsModel> AddAllocateClassroom(AllocateClassroomsModel allocation)
        {
            _context.AllocateClassrooms.Add(allocation);
            await _context.SaveChangesAsync();
            return allocation;
        }

        public async Task<AllocateClassroomsModel> UpdateAllocateClassroom(AllocateClassroomsModel allocation)
        {
            _context.AllocateClassrooms.Update(allocation);
            await _context.SaveChangesAsync();
            return allocation;
        }

        public async Task<bool> DeleteAllocateClassroom(int allocationId)
        {
            var allocation = await _context.AllocateClassrooms.FindAsync(allocationId);
            if (allocation == null)
                return false;

            _context.AllocateClassrooms.Remove(allocation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
