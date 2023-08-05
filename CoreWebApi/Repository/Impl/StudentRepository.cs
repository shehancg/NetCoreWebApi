using System.Collections.Generic;
using System.Linq;
using CoreWebApi.Dtos;
using System.Threading.Tasks;
using CoreWebApi.Models;
using CoreWebApi.Repository;
using SchoolManagementSystem.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementContext _context;

        public StudentRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public StudentModel GetStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(s => s.StudentID == studentId);
        }

        public void AddStudent(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentModel student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public async Task<StudentDetailsDto> GetStudentDetailsByIdAsync(int studentId)
        {
            return await _context.Students
                .Where(s => s.StudentID == studentId)
                .Select(s => new StudentDetailsDto
                {
                    FullName = s.FirstName + " " + s.LastName, // Concatenate first name and last name
                    ContactPerson = s.ContactPerson,
                    ContactNo = s.ContactNo,
                    EmailAddress = s.EmailAddress,
                    DateOfBirth = s.DateOfBirth.Date,
                    ClassroomName = s.Classroom.ClassroomName
                })
                .FirstOrDefaultAsync();
        }
    }
}
