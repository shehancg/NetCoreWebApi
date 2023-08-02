using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Repository.Impl
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolManagementContext _context;

        public ClassroomRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassroomModel>> GetAllClassroomsAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<ClassroomModel> GetClassroomByIdAsync(int classroomId)
        {
            return await _context.Classrooms.FindAsync(classroomId);
        }

        public async Task<ClassroomModel> AddClassroomAsync(ClassroomModel classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }

        public async Task<ClassroomModel> UpdateClassroomAsync(ClassroomModel classroom)
        {
            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }

        public async Task<bool> DeleteClassroomAsync(int classroomId)
        {
            var classroom = await _context.Classrooms.FindAsync(classroomId);
            if (classroom == null)
                return false;

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
