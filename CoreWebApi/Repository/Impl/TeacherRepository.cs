// TeacherRepository.cs

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreWebApi.Models;
using SchoolManagementSystem.API.Data;

namespace CoreWebApi.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolManagementContext _context;

        public TeacherRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<TeacherModel> GetTeacherById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<TeacherModel> AddTeacher(TeacherModel teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<TeacherModel> UpdateTeacher(TeacherModel teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<bool> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

